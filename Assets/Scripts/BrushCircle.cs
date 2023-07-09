using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushCircle : MonoBehaviour
{
    public float brushRadius = 1f;
    public float maxScale = 2f;
    public float minScale = 0.5f;
    public LayerMask meshLayer;
    public Material brushMaterial;

    private Mesh brushMesh;
    private Vector3 initialScale;

    private void Start()
    {
        CreateBrushMesh();
        UpdateBrushPosition();
        UpdateBrushScale();
        ProjectBrushOnSurface();

        initialScale = transform.localScale;
    }

    private void CreateBrushMesh()
    {
        brushMesh = new Mesh();
        brushMesh.name = "CircleBrush_Mesh";

        int circleResolution = 32;
        Vector3[] vertices = new Vector3[circleResolution + 1];
        int[] triangles = new int[circleResolution * 3];

        float angleIncrement = 360f / circleResolution;
        for (int i = 0; i < circleResolution; i++)
        {
            float angle = i * angleIncrement * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * brushRadius;
            float z = Mathf.Sin(angle) * brushRadius;
            vertices[i] = new Vector3(x, 0f, z);

            int triangleIndex = i * 3;
            triangles[triangleIndex] = i;
            triangles[triangleIndex + 1] = (i + 1) % circleResolution;
            triangles[triangleIndex + 2] = circleResolution;
        }

        // Set the center vertex at the end
        vertices[circleResolution] = Vector3.zero;

        brushMesh.vertices = vertices;
        brushMesh.triangles = triangles;
        brushMesh.RecalculateNormals();

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = brushMesh;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = brushMaterial;
    }

    private void UpdateBrushPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, meshLayer))
        {
            transform.position = hit.point;
        }
    }

    private void UpdateBrushScale()
    {
        float scale = brushRadius * 2f;
        transform.localScale = new Vector3(scale, 1f, scale);
    }

    private void ProjectBrushOnSurface()
    {
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();
        CombineInstance[] combineInstances = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combineInstances[i].mesh = meshFilters[i].sharedMesh;
            combineInstances[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combineInstances);

        Vector3[] brushVertices = brushMesh.vertices;
        Vector3[] adaptedVertices = new Vector3[brushVertices.Length];

        for (int i = 0; i < brushVertices.Length; i++)
        {
            Vector3 vertex = brushVertices[i];
            Vector3 projectedVertex = ProjectVertexOnSurface(vertex, combinedMesh);
            adaptedVertices[i] = projectedVertex;
        }

        brushMesh.vertices = adaptedVertices;
        brushMesh.RecalculateNormals();
    }

    private Vector3 ProjectVertexOnSurface(Vector3 vertex, Mesh surfaceMesh)
    {
        Vector3 closestPoint = ClosestPointOnMesh(vertex, surfaceMesh);
        Vector3 direction = closestPoint - vertex;
        Vector3 projectedVertex = vertex + direction;
        return projectedVertex;
    }

    private Vector3 ClosestPointOnMesh(Vector3 point, Mesh mesh)
    {
        Vector3 closestPoint = Vector3.zero;
        float closestDistance = Mathf.Infinity;

        foreach (var vertex in mesh.vertices)
        {
            float distance = Vector3.Distance(vertex, point);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPoint = vertex;
            }
        }

        return closestPoint;
    }

    private void Update()
    {
        UpdateBrushPosition();
        UpdateBrushScale();

        // Ограничиваем перемещение и масштабирование кольца в пределах его исходной формы
        transform.position = new Vector3(transform.position.x, initialScale.y / 2f, transform.position.z);
        float currentScale = transform.localScale.x;
        float clampedScale = Mathf.Clamp(currentScale, minScale, maxScale);
        transform.localScale = new Vector3(clampedScale, clampedScale, clampedScale);
    }

}

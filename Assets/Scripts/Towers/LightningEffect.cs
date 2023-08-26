using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class LightningEffect : MonoBehaviour
{
    [SerializeField] private List<Transform> _lightningPoints;

    [SerializeField] private int _segments = 50;

    [SerializeField] private float _deviation = 1.0f;

    private int _lightningRate;
    private int _damage;
    private int _maxEnemies;

    private DamageType _damageType;

    private LineRenderer _lineRenderer;

    private List<Enemy> _enemies;

    private bool _canLightning =false;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (_canLightning == false || _lightningPoints.Count == 0)
            return;

        DrawLightning();
    }

    public void TakeEnemies(List<Enemy> enemies, DamageType damageType, int maxEnemies, int lightningRate, int lightningDamage)
    {
        _damageType = damageType;
        _enemies = enemies;
        _maxEnemies = maxEnemies;
        _lightningRate = lightningRate;
        _damage = lightningDamage;

        if(_enemies.Count >0)
        {
            if (enemies.Count >= _maxEnemies)
            {
                for (int i = 0; i < _maxEnemies; i++)
                {
                    _lightningPoints.Add(_enemies[i].transform);
                }
            }
            else
            {
                foreach (var enemy in enemies)
                {
                    _lightningPoints.Add(enemy.transform);
                }
            }

            StartCoroutine(MoveLightning());
        }
        
    }

    private IEnumerator MoveLightning()
    {
        _canLightning = true;

        for (int i = 0; i < _lightningRate; i++)
        {
            for (int j = 0; j < _maxEnemies; j++)
            {
                if (_enemies[j].CurrentHealth > 0)
                    _enemies[j].TakeDamage(_damage, _damageType);
            }

            yield return new WaitForSeconds(1f);
        }

        _enemies.Clear();
        _lightningPoints.Clear();
        _canLightning = false;
        gameObject.Deactivate();
    }

    private void DrawLightning()
    {
        int totalPoints = (_lightningPoints.Count - 1) * _segments + 1;
        _lineRenderer.positionCount = totalPoints;
        Vector3[] points = new Vector3[totalPoints];

        int pointIndex = 0;

        for (int i = 0; i < _lightningPoints.Count - 1; i++)
        {
            for (int j = 0; j < _segments; j++)
            {
                float lerpAmount = (float)j / _segments;
                Vector3 intermediatePoint = Vector3.Lerp(_lightningPoints[i].position, _lightningPoints[i + 1].position, lerpAmount);
                points[pointIndex++] = intermediatePoint + RandomDeviation();
            }
        }

        points[pointIndex] = _lightningPoints[_lightningPoints.Count - 1].position;
        _lineRenderer.SetPositions(points);
        RemoveDisabled();
    }

    private void RemoveDisabled()
    {
        foreach (var point in _lightningPoints.Reverse<Transform>())
        {
            if (point.gameObject.activeSelf == false)
                _lightningPoints.Remove(point);
        }
    }

    private Vector3 RandomDeviation()
    {
        Vector3 deviationVector = Vector3.up * _deviation;
        deviationVector.x = Random.Range(-_deviation, _deviation);
        deviationVector.z = Random.Range(-_deviation, _deviation);
        return deviationVector;
    }
}

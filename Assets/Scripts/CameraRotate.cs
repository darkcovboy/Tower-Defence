using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _direction;
    [SerializeField] private Transform _default;
    [SerializeField] private Canvas _canvas;

    private float _speedRotation = 36;

    private void Start()
    {
        _default.rotation = Camera.main.transform.rotation;
    }

    private void Update()
    {
        if (Camera.main.transform.rotation != _direction.rotation)
            ChangeRotateCamera();
    }

    public void ChangeDirection()
    {
        _direction.rotation = _canvas.transform.rotation;
    }

    private void ChangeRotateCamera()
    {
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, _direction.rotation, _speedRotation * Time.deltaTime);
    }

    public void ReturnCameraDefault()
    {
        _direction.rotation = _default.rotation;
    }
}

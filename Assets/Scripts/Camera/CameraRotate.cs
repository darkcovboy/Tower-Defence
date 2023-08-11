using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _direction;
    [SerializeField] private Transform _default;
    [SerializeField] private Canvas _canvas;

    private float _speedRotation = 36;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _default.rotation = _camera.transform.rotation;
    }

    private void Update()
    {
        if (_camera.transform.rotation != _direction.rotation)
            ChangeRotateCamera();
    }

    public void ChangeDirection()
    {
        _direction.rotation = _canvas.transform.rotation;
    }

    private void ChangeRotateCamera()
    {
        _camera.transform.rotation = Quaternion.RotateTowards(_camera.transform.rotation, _direction.rotation, _speedRotation * Time.deltaTime);
    }

    public void ReturnCameraDefault()
    {
        _direction.rotation = _default.rotation;
    }
}

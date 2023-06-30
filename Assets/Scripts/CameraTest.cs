using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTest : MonoBehaviour
{
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}

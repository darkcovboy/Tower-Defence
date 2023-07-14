using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MeteorShoot : MonoBehaviour
{
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private int _rechargeSeconds;

    private bool _canShoot = true;
    private Button _button;
    private Camera _mainCamera;
    private ObjectManagerUI _managerUI;

    private void Start()
    {
        _button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        _mouseClick.Enable();
        _mouseClick.performed += Shoot;
    }

    private void OnDisable()
    {
        _mouseClick.performed -= Shoot;
        _mouseClick.Disable();
    }

    public void Init(ObjectManagerUI objectManagerUI, Camera mainCamera)
    {
        _managerUI = objectManagerUI;
        _mainCamera = mainCamera;
    }

    private void Shoot(InputAction.CallbackContext callbackContext)
    {

    }
}

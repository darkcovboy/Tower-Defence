using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ObjectManagerUI : MonoBehaviour
{
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTowers;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private string _tag;

    public UnityAction<bool> _event;

    private Camera _mainCamera;
    private bool _needToClose = true;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _spawnPlaceTowers = FindObjectsOfType<SpawnPlaceTower>();
    }

    private void OnEnable()
    {
        _mouseClick.Enable();
        _mouseClick.performed += Check;
        _event += IsObjectOpened;
    }

    private void OnDisable()
    {
        _mouseClick.performed -= Check;
        _mouseClick.Disable();
        _event -= IsObjectOpened;
    }

    public void CloseUI()
    {
        foreach (SpawnPlaceTower spawnPlaceTower in _spawnPlaceTowers)
        {
            spawnPlaceTower.ClosePanel();
        }
    }

    private void CurrentClickedGameObject(GameObject clickedObject)
    {
        if ((clickedObject.layer == 6 | clickedObject.layer == 0) & clickedObject.CompareTag(_tag) == false)
        {
            CloseUI();
        }
    }

    private void Check(InputAction.CallbackContext callbackContext)
    {
        if(_needToClose == false)
        { return; }

        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit) & !IsPointerOverUIObject())
        {
            if (raycastHit.transform != null)
            {
                CurrentClickedGameObject(raycastHit.transform.gameObject);
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        bool isPointerUI = false;

        foreach (var item in results)
        {
            if (item.gameObject.layer == 5)
                isPointerUI = true;
        }

        return isPointerUI;
    }


    private void IsObjectOpened(bool isObjectOpened)
    {
        _needToClose = isObjectOpened;
    }
}

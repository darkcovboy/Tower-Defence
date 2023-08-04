using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class ObjectManagerUI : MonoBehaviour
{
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTowers;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private string _tag;

    public UnityAction<bool> _event;

    private Camera _mainCamera;
    private bool _needToClose = true;
    private bool _isDesktop;

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

    public void Init(Camera camera, SpawnPlaceTower[] spawnPlaceTowers)
    {
        _mainCamera = camera;
        _spawnPlaceTowers = spawnPlaceTowers;
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

        Vector2 clickPosition;
        
        if(DeviceDefinder.isDesktop)
        {
            clickPosition = Mouse.current.position.ReadValue();
        }
        else
        {
            clickPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        Ray ray = _mainCamera.ScreenPointToRay(clickPosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit) & !IsPointerOverUIObject(clickPosition))
        {
            if (raycastHit.transform != null)
            {
                CurrentClickedGameObject(raycastHit.transform.gameObject);
            }
        }
    }

    private bool IsPointerOverUIObject(Vector2 vector)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = vector;

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

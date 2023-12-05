using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Zenject;

public class ObjectManagerUI : MonoBehaviour
{
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTowers;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private string _tag;

    public UnityAction<bool> ObjectOpened;

    private Camera _mainCamera;
    private ChoicePanel _choicePanel;
    private bool _needToClose = true;

    [Inject]
    public void Init(Camera camera, SpawnPlaceTower[] spawnPlaceTowers, ChoicePanel choicePanel)
    {
        _mainCamera = camera;
        _spawnPlaceTowers = spawnPlaceTowers;
    }

    private void OnEnable()
    {
        _mouseClick.Enable();
        _mouseClick.performed += Check;
        ObjectOpened += IsObjectOpened;
    }

    private void OnDisable()
    {
        _mouseClick.performed -= Check;
        _mouseClick.Disable();
        ObjectOpened -= IsObjectOpened;
    }

    public void CloseUI()
    {
        foreach (SpawnPlaceTower spawnPlaceTower in _spawnPlaceTowers)
        {
            spawnPlaceTower.ClosePanel();
        }
    }

    private void CurrentClickedGameObject(GameObject clickedObject, Vector2 clicklPosition)
    {
        if(clickedObject.TryGetComponent<SpawnPlaceTower>(out SpawnPlaceTower spawnPlaceTower))
        {
            spawnPlaceTower.OpenPanel();
            _choicePanel.transform.position = clicklPosition;
        }
        else
        {
            CloseUI();
        }
    }


    private void Check(InputAction.CallbackContext callbackContext)
    {
        if(_needToClose == false)
        { return; }

        Vector2 clickPosition = IsClickByDesktop();

        Ray ray = _mainCamera.ScreenPointToRay(clickPosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit) & !IsPointerOverUIObject(clickPosition))
        {
            if (raycastHit.transform != null)
            {
                CurrentClickedGameObject(raycastHit.transform.gameObject, clickPosition);
            }
        }
    }
    private Vector2 IsClickByDesktop()
    {
        if(DeviceDefinder.isDesktop)
        {
            return Mouse.current.position.ReadValue();
        }
        else
        {
            return Touchscreen.current.primaryTouch.position.ReadValue();
        }
    }

    private bool IsNotClicable(GameObject clickedObject) => ((clickedObject.layer == 6 | clickedObject.layer == 0) & clickedObject.CompareTag(_tag) == false);

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

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ObjectManagerUI : MonoBehaviour
{
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTowers;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private string _tag;
    [SerializeField] private float _layerDistance;

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
        Debug.Log(clickedObject.layer);

        if ((clickedObject.layer == 6 | clickedObject.layer == 0) & clickedObject.CompareTag(_tag) == false)
        {
            Debug.Log("Start Close");
            CloseUI();
        }
    }

    private void Check(InputAction.CallbackContext callbackContext)
    {
        if(_needToClose == false)
        { return; }

        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit, _layerDistance))
        {
            if (raycastHit.transform != null)
            {
                CurrentClickedGameObject(raycastHit.transform.gameObject);
            }
        }
    }

    private void IsObjectOpened(bool isObjectOpened)
    {
        _needToClose = isObjectOpened;
    }
}

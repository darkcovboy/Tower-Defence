using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectManagerUI : MonoBehaviour
{
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTowers;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private string _tag;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _spawnPlaceTowers = FindObjectsOfType<SpawnPlaceTower>();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _mouseClick.Enable();
        _mouseClick.performed += Check;
    }

    private void OnDisable()
    {
        _mouseClick.performed -= Check;
        _mouseClick.Disable();
    }

    private void Check(InputAction.CallbackContext callbackContext)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (raycastHit.transform != null)
            {
                CurrentClickedGameObject(raycastHit.transform.gameObject);
            }
        }
    }

    public void CurrentClickedGameObject(GameObject clickedObject)
    {
        if (clickedObject.layer != _layerMask & clickedObject.CompareTag(_tag) == false)
        {
            Debug.Log("Start Close");
            CloseUI();
        }
    }

    public void CloseUI()
    {
        foreach (SpawnPlaceTower spawnPlaceTower in _spawnPlaceTowers)
        {
            spawnPlaceTower.ClosePanel();
        }
    }
}

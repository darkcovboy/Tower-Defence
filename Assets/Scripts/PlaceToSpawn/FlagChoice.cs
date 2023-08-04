using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class FlagChoice : MonoBehaviour
{
    [SerializeField] private GameObject _flag;
    [SerializeField] private InputAction _flagAction;
    [SerializeField, Range(15, 40)] private float _speed;
    [SerializeField] private Transform _target;

    private Camera _mainCamera;
    private BarracksTower _barracksTower;

    private readonly string _tag = "RangeField";

    private void Awake()
    {
        _mainCamera = Camera.main;
        _flag.transform.position = _target.position;
    }

    private void OnEnable()
    {
        _flagAction.Enable();
        _flagAction.performed += Check;
    }

    private void OnDisable()
    {
        _flagAction.performed -= Check;
        _flagAction.Disable();
    }

    public void Init(ref BarracksTower barracksTower)
    {
        _barracksTower = barracksTower;
    }

    private void Check(InputAction.CallbackContext callbackContext)
    {
        RaycastHit raycastHit;

        Vector2 clickPosition;

        if (DeviceDefinder.isDesktop)
        {
            clickPosition = Mouse.current.position.ReadValue();
        }
        else
        {
            clickPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        Ray ray = _mainCamera.ScreenPointToRay(clickPosition);

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.transform != null)
            {
                if(raycastHit.transform.CompareTag(_tag))
                {
                    _flag.transform.position = raycastHit.point;
                    _flag.Deactivate();
                    _barracksTower.ChangePoint(_flag.transform);
                    gameObject.Deactivate();
                }
            }
        }
    }

    private IEnumerator MoveToObject(RaycastHit raycastHit)
    {
        while(Vector3.Distance(_flag.transform.position, raycastHit.point) > 0.5f)
        {
            _flag.transform.position = Vector3.MoveTowards(_flag.transform.position, raycastHit.point,Time.deltaTime *_speed );
            yield return null;
        }

        Debug.Log("FlagChoice");
        _flag.Deactivate();
        _barracksTower.ChangePoint(_flag.transform);
        gameObject.Deactivate();
    }
}

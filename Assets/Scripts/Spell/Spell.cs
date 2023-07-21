using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum SpellType
{
    Meteor,
    IceCircle
}

public class Spell : MonoBehaviour
{
    [SerializeField] private InputAction _mouseClick;
    [SerializeField] private int _rechargeSeconds;

    private bool _canShoot = false;
    private SpellButton _spellButton;
    private Camera _mainCamera;
    private ObjectManagerUI _managerUI;

    private void OnEnable()
    {
        _mouseClick.Enable();
        _mouseClick.performed += TryAction;
    }

    private void OnDisable()
    {
        _mouseClick.performed -= TryAction;
        _mouseClick.Disable();
    }

    public void Init(ObjectManagerUI objectManagerUI, Camera mainCamera, SpellButton meteorShootButton)
    {
        _managerUI = objectManagerUI;
        _mainCamera = mainCamera;
        _spellButton = meteorShootButton;
        _spellButton.GetComponent<Button>().onClick.AddListener(Select);
        _spellButton.GetComponent<Button>().onClick.AddListener(_managerUI.CloseUI);
    }

    public void Select()
    {
        _canShoot = true;
        _managerUI.CloseUI();
        _managerUI.Deactivate();
        _spellButton.Select();
    }

    private void TryAction(InputAction.CallbackContext callbackContext)
    {
        if (_canShoot == false)
            return;

        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (!IsPointerOverUIObject())
            {
                if (raycastHit.transform != null)
                {
                    Vector3 newPosition = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                    transform.position = newPosition;
                    StartCoroutine(MakeAction(raycastHit.point));
                    StartCoroutine(Reload());
                }
            }
            else
            {
                Deselect();
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

    private void Deselect()
    {
        _canShoot = false;
        _managerUI.Activate();
        _spellButton.DeSelect();
    }


    private IEnumerator Reload()
    {
        Deselect();
        _spellButton.OffButton(_rechargeSeconds);

        for (int i = 0; i < _rechargeSeconds; i++)
        {
            yield return new WaitForSeconds(1f);
        }

        _spellButton.OnButton();
    }

    protected virtual IEnumerator MakeAction(Vector3 endPosition)
    {
        yield break;
    }
}

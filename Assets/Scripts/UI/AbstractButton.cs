using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    protected Button ButtonComponent;

    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
    }

    private void OnEnable()
    {
        ButtonComponent.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ButtonComponent.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}

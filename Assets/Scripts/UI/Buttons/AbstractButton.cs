using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField] protected AudioSource AudioSource;

    protected SceneFader _sceneFader;
    protected Button ButtonComponent;

    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        _sceneFader = FindObjectOfType<SceneFader>();
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

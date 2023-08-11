using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField] protected SourceAudio AudioSource;
    [SerializeField] protected AudioDataProperty AudioDataProperty;

    protected SceneFader SceneFader;
    protected Button ButtonComponent;


    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        SceneFader = FindObjectOfType<SceneFader>();
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

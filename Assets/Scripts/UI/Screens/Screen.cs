using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected RestartSceneButton RestartSceneButton;
    [SerializeField] protected MainMenuButton MainMenuButton;
    [SerializeField] protected CanvasGroup CanvasGroup;

    public virtual void OpenScreen()
    {
        gameObject.Activate();
    }

    public virtual void CloseScreen()
    {
        gameObject.Deactivate();
    }
}

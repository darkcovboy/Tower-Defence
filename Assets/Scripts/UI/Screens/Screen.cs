using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected Button[] _buttons;
    [SerializeField] protected CanvasGroup _canvasGroup;

    public virtual void OpenScreen()
    {
        gameObject.Activate();
    }

    public virtual void CloseScreen()
    {
        gameObject.Deactivate();
    }
}

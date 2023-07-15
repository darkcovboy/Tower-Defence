using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected Button[] _buttons;
    [SerializeField] protected CanvasGroup _canvasGroup;

    public virtual void OpenScreen()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}

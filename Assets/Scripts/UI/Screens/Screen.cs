using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected Button[] _buttons;
    [SerializeField] protected CanvasGroup _canvasGroup;

    //private void Start()
    //{
    //    _canvasGroup = GetComponent<CanvasGroup>();
    //    //CloseScreen();
    //}

    public virtual void OpenScreen()
    {
        gameObject.SetActive(true);
        //InteractableButtons(true);
    }

    public virtual void CloseScreen()
    {
        gameObject.SetActive(false);
        //InteractableScreen(false, 0);
        //InteractableButtons(false);
    }

    //public virtual void InteractableButtons(bool flag)
    //{
    //    foreach (var button in _buttons)
    //    {
    //        button.interactable = flag;
    //    }
    //}

    //public virtual void InteractableScreen(bool flag, int alpha)
    //{
    //    _canvasGroup.interactable = flag;
    //    _canvasGroup.blocksRaycasts = flag;
    //    _canvasGroup.alpha = alpha;
    //}
}

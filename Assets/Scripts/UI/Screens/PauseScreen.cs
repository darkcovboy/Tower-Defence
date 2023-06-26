using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        CloseScreen();
    }

    public void OpenScreen()
    {
        InteractableScreen(true, 1);
        Time.timeScale = 0;
        InteractableButtons(true);
    }

    public void CloseScreen()
    {
        Time.timeScale = 1;
        InteractableScreen(false, 0);
        InteractableButtons(false);
    }

    private void InteractableScreen(bool flag, int alpha)
    {
        _canvasGroup.interactable = flag;
        _canvasGroup.blocksRaycasts = flag;
        _canvasGroup.alpha = alpha;
    }
    
    private void InteractableButtons(bool flag)
    {
        foreach (var button in _buttons)
        {
            button.interactable = flag;
        }
    }
}

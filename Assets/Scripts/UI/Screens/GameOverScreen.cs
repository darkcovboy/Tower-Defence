using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dying += OpenScreen;
    }

    private void OnDisable()
    {
        _player.Dying -= OpenScreen;
    }

    private void Start()
    {
        CloseScreen();
    }

    public void OpenScreen()
    {
        InteractableScreen(true, 1);
        InteractableButtons(true);
    }

    public void CloseScreen()
    {
        InteractableScreen(false, 0);
        InteractableButtons(false);
    }

    private void InteractableButtons(bool flag)
    {
        foreach (var button in _buttons)
        {
            button.interactable = flag;
        }
    }

    private void InteractableScreen(bool flag,int alpha)
    {
        _canvasGroup.interactable = flag;
        _canvasGroup.blocksRaycasts = flag;
        _canvasGroup.alpha = alpha;
    }
}

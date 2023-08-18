using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    [SerializeField] private ReturnGameButton _closeButton;
    private ObjectManagerUI _objectManagerUI;

    public void Init(ObjectManagerUI objectManagerUI, FullVideo fullVideo, SoundButton soundButton)
    {
        _objectManagerUI = objectManagerUI;
        RestartSceneButton.Init(fullVideo);
        MainMenuButton.Init(fullVideo);
        _closeButton.GetComponent<Button>().onClick.AddListener(soundButton.Play);
    }

    public override void OpenScreen()
    {
        Time.timeScale = 0;
        _objectManagerUI.CloseUI();
        base.OpenScreen();
    }

    public override void CloseScreen()
    {
        Time.timeScale = 1;
        base.CloseScreen();
    }
}

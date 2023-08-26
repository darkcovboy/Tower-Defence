using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    //[SerializeField] private ReturnGameButton _returnGameButton;
    [SerializeField] private GameObject _pause;

    private ObjectManagerUI _objectManagerUI;

    public void Init(ObjectManagerUI objectManagerUI,FullVideo fullVideo,SoundButton soundButton)
    {
        _objectManagerUI = objectManagerUI;
        MainMenuButton.Init(fullVideo, soundButton);
        RestartSceneButton.Init(fullVideo, soundButton);
        ReturnGameButton.Init(soundButton);
    }

    public override void OpenScreen()
    {
        Time.timeScale = 0;
        _pause.Activate();
        _objectManagerUI.CloseUI();
        base.OpenScreen();
    }

    public override void CloseScreen()
    {
        Time.timeScale = 1;
        _pause.Deactivate();
        base.CloseScreen();
    }
}

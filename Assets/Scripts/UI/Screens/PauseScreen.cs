using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    private ObjectManagerUI _objectManagerUI;

    public void Init(ObjectManagerUI objectManagerUI,FullVideo fullVideo,SoundButton soundButton)
    {
        _objectManagerUI = objectManagerUI;
        MainMenuButton.Init(fullVideo, soundButton);
        RestartSceneButton.Init(fullVideo, soundButton);
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

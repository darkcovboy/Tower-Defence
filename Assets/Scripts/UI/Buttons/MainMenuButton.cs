using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : AbstractButton
{
    private string _mainMenuLevelKey = "MainMenu";
    private FullVideo _fullVideo;

    public void Init(FullVideo fullVideo)
    {
        _fullVideo = fullVideo;
    }

    protected override void OnButtonClick()
    {
        GoMainMenu();
    }

    private void GoMainMenu()
    {
        _fullVideo.Show(_mainMenuLevelKey);
    }
}

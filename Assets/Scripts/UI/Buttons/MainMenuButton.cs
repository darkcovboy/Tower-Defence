using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : AbstractButton
{
    private string _mainMenuLevelKey = "MainMenu";
    private FullVideo _fullVideo;
    private SoundButton _soundButton;

    public void Init(FullVideo fullVideo, SoundButton soundButton)
    {
        _fullVideo = fullVideo;
        _soundButton = soundButton;
    }

    protected override void OnButtonClick()
    {
        _soundButton.Play();
        GoMainMenu();
    }

    private void GoMainMenu()
    {
        _fullVideo.Show(_mainMenuLevelKey);
    }
}

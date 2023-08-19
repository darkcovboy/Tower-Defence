using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RestartSceneButton : AbstractButton
{
    private string _currentScene;
    private FullVideo _fullVideo;
    private SoundButton _soundButton;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    public void Init(FullVideo fullVideo, SoundButton soundButton)
    {
        _fullVideo = fullVideo;
        _soundButton = soundButton;
    }

    protected override void OnButtonClick()
    {
        _soundButton.Play();
        Restart();
    }

    private void Restart()
    {
        _fullVideo.Show(_currentScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RestartSceneButton : AbstractButton
{
    private string _currentScene;
    private FullVideo _fullVideo;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    public void Init(FullVideo fullVideo)
    {
        _fullVideo = fullVideo;
    }

    protected override void OnButtonClick()
    {
        Restart();
    }

    private void Restart()
    {
        _fullVideo.Show(_currentScene);
    }
}

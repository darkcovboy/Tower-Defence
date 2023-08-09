using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneButton : AbstractButton
{
    private string _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    protected override void OnButtonClick()
    {
        Restart();
    }

    private void Restart()
    {
        Time.timeScale = 1;
        AudioSource.Play();
        SceneFader.FadeTo(_currentScene);
    }
}

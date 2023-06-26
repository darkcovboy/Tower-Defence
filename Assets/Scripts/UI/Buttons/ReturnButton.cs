using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : AbstractButton
{
    [SerializeField] private SceneFader _sceneFader;

    private string _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }

    protected override void OnButtonClick()
    {
        _sceneFader.FadeTo(_currentScene);
    }
}

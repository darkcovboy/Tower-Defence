using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : AbstractButton
{
    private string _mainMenu = "MainMenu";

    private void Start()
    {
        SceneFader = FindObjectOfType<SceneFader>();
    }

    protected override void OnButtonClick()
    {
        Time.timeScale = 1;
        AudioSource.Play(AudioDataProperty.Key);
        SceneFader.FadeTo(_mainMenu);
    }
}

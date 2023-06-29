using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : AbstractButton
{
    private string _mainMenu = "MainMenu";

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}

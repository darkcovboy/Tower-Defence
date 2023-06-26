using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenuButton : AbstractButton
{
    private string _levelSelect = "LevelSelectScene";

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_levelSelect);
    }
}

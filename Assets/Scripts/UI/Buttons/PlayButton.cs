using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    private string _levelSelect = "LevelSelectScene";

    protected override void OnButtonClick()
    {
        _sceneFader.FadeTo(_levelSelect);
    }
}

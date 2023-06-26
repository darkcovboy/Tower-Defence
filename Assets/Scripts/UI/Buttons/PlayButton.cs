using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    [SerializeField] private SceneFader _sceneFader;

    private string _levelSelect = "LevelSelectScene";

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_levelSelect);
    }
}

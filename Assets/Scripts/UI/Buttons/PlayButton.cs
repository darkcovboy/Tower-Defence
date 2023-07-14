using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    //private string _levelSelect = "LevelSelectScene";
    [SerializeField] private Canvas _canvas;

    protected override void OnButtonClick()
    {
        _canvas.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    private ObjectManagerUI _objectManagerUI;

    public void Init(ObjectManagerUI objectManagerUI)
    {
        _objectManagerUI = objectManagerUI;
    }

    public override void OpenScreen()
    {
        Time.timeScale = 0;
        _objectManagerUI.CloseUI();
        base.OpenScreen();
    }

    public override void CloseScreen()
    {
        Time.timeScale = 1;
        base.CloseScreen();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGameButton : AbstractButton
{
    [SerializeField] private PauseScreen _pauseScreen;

    protected override void OnButtonClick()
    {
        _pauseScreen.CloseScreen();
    }
}

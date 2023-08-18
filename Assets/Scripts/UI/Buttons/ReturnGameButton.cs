using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGameButton : AbstractButton
{
    [SerializeField] private PauseScreen _pauseScreen;

    private SoundButton _soundButton;

    public void Init(SoundButton soundButton)
    {
        _soundButton = soundButton;
    }

    protected override void OnButtonClick()
    {
        Time.timeScale = 1;
        _soundButton.Play();
    }
}

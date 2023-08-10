using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseButton : AbstractButton
{
    [SerializeField] private PauseScreen _pauseScreen;

    protected override void OnButtonClick()
    {
        AudioSource.Play(AudioDataProperty.Key);
        _pauseScreen.OpenScreen();
    }
}

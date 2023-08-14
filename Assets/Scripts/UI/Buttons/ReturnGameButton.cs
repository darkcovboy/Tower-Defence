using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGameButton : AbstractButton
{
    [SerializeField] private PauseScreen _pauseScreen;

    private Coroutine _coroutine;

    protected override void OnButtonClick()
    {
        Time.timeScale = 1;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(PlayToClose());
    }

    IEnumerator PlayToClose()
    {
        var waitForSeconds = new WaitForSeconds(0.3f);
        AudioSource.Play(AudioDataProperty.Key);
        yield return waitForSeconds;
        _pauseScreen.CloseScreen();
    }
}

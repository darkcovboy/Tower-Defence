using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtons : AbstractButton
{
    [SerializeField] private LeaderboardScreen _leaderboardScreen;

    private Coroutine coroutine;

    protected override void OnButtonClick()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CloseScreen());
    }

    IEnumerator CloseScreen()
    {
        AudioSource.Play();
        yield return new WaitForSeconds(0.3f);
        _leaderboardScreen.gameObject.SetActive(false);
    }
}

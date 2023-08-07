using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardButton : AbstractButton
{
   [SerializeField] private LeaderboardScreen _leaderboardScreen;

    protected override void OnButtonClick()
    {
        AudioSource.Play();
        _leaderboardScreen.gameObject.SetActive(true);
    }
}

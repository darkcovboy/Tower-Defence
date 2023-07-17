using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtons : AbstractButton
{
    [SerializeField] private LeaderboardScreen _leaderboardScreen;

    protected override void OnButtonClick()
    {
        _leaderboardScreen.gameObject.SetActive(false);
    }
}

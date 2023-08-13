using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExtraLive : AbstractButton
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Player _player;

    protected override void OnButtonClick()
    {
        _player.AddExtraLive(100);
        _gameOverScreen.SetActive(false);
    }
}

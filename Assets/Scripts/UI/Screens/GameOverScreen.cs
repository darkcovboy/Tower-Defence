using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameOverScreen;

    private void OnEnable()
    {
        _player.Dying += OpenScreen;
    }

    private void OnDisable()
    {
        _player.Dying -= OpenScreen;
    }

    public override void OpenScreen()
    {
        _gameOverScreen.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

[RequireComponent(typeof(AudioSource))]
public class GameOverScreen : Screen
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioDataProperty _audioData;

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
        gameObject.GetComponent<SourceAudio>().Play(_audioData.Key);
    }
}

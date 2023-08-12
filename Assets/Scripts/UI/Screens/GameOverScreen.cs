using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

[RequireComponent(typeof(AudioSource))]
public class GameOverScreen : Screen
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioDataProperty _audioData;

    private Player _player;
    private AudioSource _music;

    private void OnDisable()
    {
        _player.Dying -= OpenScreen;
        _music.GetComponent<SourceAudio>().Play();
    }

    public void Init(Player player, AudioSource music)
    {
        _player = player;
        _music = music; 
        _player.Dying += OpenScreen;
        _music.GetComponent<SourceAudio>().Stop();
    }

    public override void OpenScreen()
    {
        _gameOverScreen.SetActive(true);
        gameObject.GetComponent<SourceAudio>().Play(_audioData.Key);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameOverScreen : Screen
{
    [SerializeField] private GameObject _gameOverScreen;

    private Player _player;
    private AudioSource _music;

    private void OnDisable()
    {
        _player.OnDie -= OpenScreen;
    }

    public void Init(Player player, AudioSource music)
    {
        _player = player;
        _music = music;
        _player.OnDie += OpenScreen;
    }

    public override void OpenScreen()
    {
        _gameOverScreen.Activate();
        Time.timeScale = 0f;
        _music.GetComponent<MusicPlayer>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
    }

    public override void CloseScreen()
    {
        _gameOverScreen.Deactivate();
        Time.timeScale = 1f;
        _music.GetComponent<MusicPlayer>().Play();
    }
}

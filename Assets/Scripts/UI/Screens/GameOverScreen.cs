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
    [SerializeField] private AudioDataProperty _musicData;

    private Player _player;
    private AudioSource _music;

    private void OnDisable()
    {
        _player.Dying -= OpenScreen;
    }

    public void Init(Player player, AudioSource music, FullVideo fullVideo, SoundButton soundButton)
    {
        _player = player;
        _music = music;
        _player.Dying += OpenScreen;

        RestartSceneButton.Init(fullVideo,soundButton);
        MainMenuButton.Init(fullVideo, soundButton);
    }

    public override void OpenScreen()
    {
        _gameOverScreen.Activate();
        _music.GetComponent<MusicPlayer>().Stop();
        gameObject.GetComponent<SourceAudio>().Play(_audioData.Key);
    }

    public override void CloseScreen()
    {
        _gameOverScreen.Deactivate();
        _music.GetComponent<MusicPlayer>().Play();
    }
}

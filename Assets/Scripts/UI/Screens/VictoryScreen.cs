using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
[RequireComponent(typeof(AudioSource))]
public class VictoryScreen : Screen
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private Star[] _stars;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private int _countStars;
    private AudioSource _music;
    private Spawner _spawner;
    private Coroutine _coroutine;

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OpenScreen;
    }

    public void Init(Spawner spawner, AudioSource music, FullVideo fullVideo, SoundButton soundButton)
    {
        _spawner = spawner;
        _music = music;
        _spawner.AllEnemysDied += OpenScreen;

        RestartSceneButton.Init(fullVideo,soundButton);
        MainMenuButton.Init(fullVideo, soundButton);
    }

    public override void OpenScreen()
    {
        _screen.SetActive(true);
        _music.GetComponent<MusicPlayer>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
        //StartCoroutine(ShowStars());
    }

    public void SetScore(float points)
    {
        _pointsText.text = points.ToString();
    }

    public void SetStars(int stars)
    {
        _countStars = stars;
    }

    public void PlayShowStars()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ShowStars());
    }

    IEnumerator ShowStars()
    {
        var waitForSeconds = new WaitForSeconds(1f);

        for (int i = 0; i < _countStars; i++)
        {
            yield return waitForSeconds;
            _stars[i].gameObject.SetActive(true);
            _stars[i].PlayAnimation();
        }
    }
}

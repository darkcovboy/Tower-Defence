using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Star[] _stars;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private int _countStars;
    private AudioSource _music;
    private IDiedHandler _diedHandler;
    private Coroutine _coroutine;

    [Inject]
    public void Init(IDiedHandler diedHandler, AudioSource music)
    {
        _diedHandler = diedHandler;
        _diedHandler.AllEnemysDied += OpenScreen;
        _music = music;
    }

    private void OnValidate()
    {
        if(_audio == null)
            _audio = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        _diedHandler.AllEnemysDied -= OpenScreen;
    }

    public void OpenScreen()
    {
        gameObject.SetActive(true);
        _music.GetComponent<MusicPlayer>().Stop();
        _audio.Play();
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
        for (int i = 0; i < _countStars; i++)
        {
            yield return new WaitForSeconds(1f);
            _stars[i].gameObject.Activate();
            _stars[i].PlayAnimation();
        }
    }
}

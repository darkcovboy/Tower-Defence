using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
[RequireComponent(typeof(AudioSource))]
public class VictoryScreen : Screen
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Star[] _stars;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private AudioDataProperty _audioData;

    private int _countStars;

    private void OnEnable()
    {
        _spawner.AllEnemysDied += OpenScreen;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OpenScreen;
    }

    public override void OpenScreen()
    {
        _screen.SetActive(true);
        gameObject.GetComponent<SourceAudio>().Play(_audioData.Key);
        StartCoroutine(ShowStars());
    }

    public void SetScore(float points)
    {
        _pointsText.text = points.ToString();
    }

    public void SetStars(int stars)
    {
        _countStars = stars;
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

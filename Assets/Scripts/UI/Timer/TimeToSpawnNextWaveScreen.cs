using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeToSpawnNextWaveScreen : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _timerWaveScreen;
    [SerializeField] private TMP_Text _timerTxt;
    [SerializeField] private NextWaveScreen _nextWaveScreen; 

    private float _timeLeftBeforeTheWave = 15f;
    private float _timer;

    private void OnEnable()
    {
        _spawner.AllEnemysSpawned += OnScreenTimer;
        _timer = _timeLeftBeforeTheWave;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysSpawned -= OnScreenTimer;
    }

    private void Update()
    {
        if (_timerTxt.gameObject.activeSelf == true)
        {
            _timer -= Time.deltaTime;
            _timerTxt.text = _timer.ToString("0.0");

            if (_timer <= 0)
            {
                _timer = _timeLeftBeforeTheWave;
                _spawner.NextWaves();
                _timerTxt.gameObject.SetActive(false);
                _nextWaveScreen.gameObject.SetActive(false);
            }
        }
    }

    private void OnScreenTimer()
    {
        _timerTxt.gameObject.SetActive(true);
        _nextWaveScreen.gameObject.SetActive(true);
    }

    public void ResetTimer()
    {
        _timer = 0f;
    }
}

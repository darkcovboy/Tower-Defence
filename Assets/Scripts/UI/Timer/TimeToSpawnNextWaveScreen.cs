using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeToSpawnNextWaveScreen : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _timerWaveScreen;
    [SerializeField] private TMP_Text _timerTxt;

    private float _timeLeftBeforeTheWave = 3f;
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
            }
        }
    }

    private void OnScreenTimer()
    {
        _timerTxt.gameObject.SetActive(true);
    }
}

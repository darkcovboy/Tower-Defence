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
    [SerializeField] private Player _player;

    private float _timeLeftBeforeTheWave = 15f;
    private float _timer;
    private bool _playerDied = false;

    private void OnEnable()
    {
        _spawner.AllEnemysSpawned += OnScreenTimer;
        _timer = _timeLeftBeforeTheWave;
        _player.Dying += SetPlayerDead;
        //_adButton.PlayerIsAlive += SetPlayerAlive;
    }

    private void OnDisable()
    {
        _player.Dying -= SetPlayerDead;
        _spawner.AllEnemysSpawned -= OnScreenTimer;
        //_adButton.PlayerIsAlive -= SetPlayerAlive;
    }

    private void Update()
    {
        if (!_playerDied)
        {
            if (_timerTxt.gameObject.activeSelf == true)
            {
                _timer -= Time.deltaTime;
                _timerTxt.text = _timer.ToString("0.0");

                if (_timer <= 0)
                {
                    _timer = _timeLeftBeforeTheWave;
                    _spawner.NextWaves();
                    _timerTxt.gameObject.Deactivate();
                    _nextWaveScreen.gameObject.Deactivate();
                }
            }
        }
    }

    public void SetPlayerAlive() => _playerDied = false;

    public void ResetTimer()
    {
        _timer = 0f;
    }
    private void OnScreenTimer()
    {
        _timerTxt.gameObject.Activate();
        _nextWaveScreen.gameObject.Activate();
    }

    private void SetPlayerDead() => _playerDied = true;

}

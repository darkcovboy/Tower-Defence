using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _waveSpawner.EnemyCountChanged += OnValueChanged;
        _spawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChanged;
        _waveSpawner.EnemyCountChanged -= OnValueChanged;
    }
}

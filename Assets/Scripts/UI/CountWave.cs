using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _currentWaveNumber;
    [SerializeField] private TMP_Text _maxWaveNumber;

    private void OnEnable()
    {
        _spawner.WaveChanged += OnChangedWaveNumber;
    }

    private void OnDisable()
    {
        _spawner.WaveChanged -= OnChangedWaveNumber;
    }

    private void OnChangedWaveNumber(int currentWave, int maxWaveCount)
    {
        _currentWaveNumber.text = currentWave.ToString();
        _maxWaveNumber.text = maxWaveCount.ToString();
    }
}

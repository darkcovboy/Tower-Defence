using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _wavesText;

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
        _wavesText.text = currentWave.ToString() + "/" + maxWaveCount.ToString();
    }
}

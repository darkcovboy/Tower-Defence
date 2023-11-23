using UnityEngine;
using TMPro;
using Zenject;

public class CountWave : MonoBehaviour
{
    [SerializeField] private TMP_Text _wavesText;

    private Spawner _spawner;

    [Inject]
    public void Constructor(Spawner spawner)
    {
        _spawner = spawner;
    }

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

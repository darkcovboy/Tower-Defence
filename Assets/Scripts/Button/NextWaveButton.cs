using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemysSpawned += OnAllEnemySpawned;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysSpawned -= OnAllEnemySpawned;

    }

    private void OnAllEnemySpawned()
    {

    }

    private void OnNextWaveButtonClick()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWaves : MonoBehaviour
{
    private WaveSpawner _wavespawner;

    private void Awake()
    {
        _wavespawner = GameObject.Find("WaveController").GetComponent<WaveSpawner>();
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesLeft == 0)
        {
            _wavespawner.LaunchWave();
        }
    }
}

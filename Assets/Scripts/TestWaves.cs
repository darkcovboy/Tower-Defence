using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWaves : MonoBehaviour
{
    private WaveSpawner _wavespawner;
    [SerializeField]private Transform _spawns;

    private void Awake()
    {
        _wavespawner = GameObject.Find("WaveController").GetComponent<WaveSpawner>();
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("����� �����");

        if (enemiesLeft == 0)
        {
            Debug.Log("����� 0");
            _wavespawner.LaunchWave();
        }
    }
}

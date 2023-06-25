using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private TestSpawner _testSpawner;

    private void OnEnable()
    {
        _testSpawner.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _testSpawner.EnemyCountChanged -= OnValueChanged;
    }
}

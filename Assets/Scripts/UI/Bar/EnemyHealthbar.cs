using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : Bar
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Gradient _gradient;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnEnemyHealthChanged;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnEnemyHealthChanged;
    }

    private void OnEnemyHealthChanged(int health, int maxHealth)
    {
        OnValueChanged(health, maxHealth);
        Slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(Slider.value);
    }
}

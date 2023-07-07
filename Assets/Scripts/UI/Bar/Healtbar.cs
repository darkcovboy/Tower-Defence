using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtbar : Bar
{
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;

    /*

    private void OnEnable()
    {
        _player.HealthChanged += OnPlayerHealtChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged += OnPlayerHealtChanged;
    }

    private void OnPlayerHealtChanged(int health, int maxHealth)
    {
        OnValueChanged(health, maxHealth);
        Slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(Slider.value);
    }

    */
}

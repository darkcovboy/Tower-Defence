using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorHealthbar : Bar
{
    [SerializeField] private Warrior _warrior;
    [SerializeField] private Gradient _gradient;

    private void OnEnable()
    {
        _warrior.ChangeHealth += OnWarriorHealthChanged;
    }

    private void OnDisable()
    {
        _warrior.ChangeHealth -= OnWarriorHealthChanged;
    }

    private void OnWarriorHealthChanged(int health, int maxHealth)
    {
        OnValueChanged(health, maxHealth);
        Slider.fillRect.GetComponent<Image>().color = _gradient.Evaluate(Slider.value);
    }
}

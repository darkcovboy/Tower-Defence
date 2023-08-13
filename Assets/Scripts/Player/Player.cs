using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private int _currentHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Dying;
    public event UnityAction ExtraLive;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void SetStartHealth(int health)
    {
        _maxHealth = health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int health)
    {
        if (health <= 0)
            throw new ArgumentException();

        _currentHealth = 0;
        _currentHealth += health;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void AddExtraLive(int health)
    {
        if (health <= 0)
            throw new ArgumentException();

        _currentHealth += health;
        ExtraLive?.Invoke();
        HealthChanged?.Invoke(_currentHealth);
    }

    public void Die()
    {
        Dying.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private int _currentHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Dying;

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

    public void Die()
    {
        gameObject.Deactivate();
        Dying.Invoke();
    }
}

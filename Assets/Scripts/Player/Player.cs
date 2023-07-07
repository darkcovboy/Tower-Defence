using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public int Money { get; private set; }

    public event UnityAction<int> HealthChanged;
    public event UnityAction Dying;

    private void Start()
    {
        _currentHealth = _health;
        HealthChanged?.Invoke(_currentHealth);
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

using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour, IDamagable, IHealthHandler, IHealible
{
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private int _currentHealth;

    public event Action<int> OnHealthChanged;
    public event UnityAction ExtraLive;
    public event Action OnDie;

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void SetStartHealth(int startHealth)
    {
        _maxHealth = startHealth;
    }

    public void ApplyDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentException(nameof(damage));

        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int health)
    {
        if (health <= 0)
            throw new ArgumentException();

        _currentHealth = health;
        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void AddExtraLive(int health)
    {
        if (health <= 0)
            throw new ArgumentException();

        _currentHealth = health;
        ExtraLive?.Invoke();
        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}

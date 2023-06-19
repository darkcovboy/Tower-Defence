using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;

    private Player _target;
    private Warrior _warrior;
    private int _currentHealth;
    private bool _dieCheck = false;

    public bool HaveEnemy => _warrior == null;
    public int Damage => _damage;
    public bool DieCheck => _dieCheck;
    public int Reward => _reward;
    public Player Target => _target;
    public Warrior Warrior => _warrior;
    public int CurrentHealth => _currentHealth;

    public event UnityAction<Enemy> Dying;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void TakeDamage(int damage, Type type)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void Init(Player target, Warrior warrior)
    {
        _target = target;
        _warrior = warrior;
    }

    public void Init(Warrior warrior)
    {
        _warrior = warrior;
    }

    public void DyingEnemy()
    {
        Dying.Invoke(this);
    }

    public void OnDie()
    {
        _dieCheck = true;
    }

    public void TargetNull()
    {
        _warrior = null;
    }
}

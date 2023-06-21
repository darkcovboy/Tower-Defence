using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Warrior : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private Enemy _enemy; 
    private int _currentHealth;
    private bool _die = false;
    private BarracksTower _barracks;

    public bool Battle { get; private set; } = false;
    public int Damage => _damage;
    public bool DieWarrior => _die;
    public int CurrentHealth => _currentHealth;
    public Enemy Enemy => _enemy;
    public bool HaveEnemy => _enemy == null;
            
    public event UnityAction<int,int> ChangeHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
        ChangeHealth?.Invoke(_currentHealth, _health);
    }

    public void SendData(int damage, Transform _target, BarracksTower barracksTower)
    {
        _damage = damage;
        GetComponent<WarriorMoveState>().TargetPosition = _target;
        _barracks = barracksTower;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        ChangeHealth?.Invoke(_currentHealth,_health);

        if(_currentHealth <= 0)
        {
            _barracks.OnWarriorDied?.Invoke();
        }
    }

    public void Init(Enemy enemy)
    {
        _enemy = enemy; 
    }

    public void Die()
    {
        _die = true;
    }

    public void EnemyDead()
    {
        _enemy = null;
    }

    public void CallToFight(bool flag)
    {
        Battle = flag;
    }
}

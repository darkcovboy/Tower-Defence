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
    private BarracksTower _barracksTower;
    private Transform _target;

    public bool Battle { get; private set; } = false;
    public int Damage => _damage;
    public bool DieWarrior => _die;
    public int CurrentHealth => _currentHealth;
    public Enemy Enemy => _enemy;
    public bool HaveEnemy => _enemy == null;

    public Transform Target => _target;
            
    public event UnityAction<int,int> ChangeHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        if (gameObject == null)
        {
            return;
        }
    }

    public void SendData(int damage, Transform target, BarracksTower barracks)
    {
        _damage = damage;
        _target = target;
        GetComponent<WarriorMoveState>().TargetPosition = target;
        _barracksTower = barracks;
    }

    public void SendData(Transform target)
    {
        _target = target;
        GetComponent<WarriorMoveState>().TargetPosition = target;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        ChangeHealth?.Invoke(_currentHealth,_health);

        if(_currentHealth <= 0)
        {
            _barracksTower.OnWarriorDied?.Invoke();
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

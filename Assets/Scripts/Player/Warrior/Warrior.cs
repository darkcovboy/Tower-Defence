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

    public int Damage => _damage;
    public bool DieWarrior => _die;
    public int CurrentHealth => _currentHealth;
    public Enemy Enemy => _enemy;
            
    public event UnityAction<int,int> ChangeHealth;

    private void OnEnable()
    {
        _currentHealth = _health;
        Debug.Log(_currentHealth + " Новая жыыызнь" + _health);
    }

    private void Update()
    {
        if (gameObject == null)
        {
            return;
        }
    }
    
    public void SendData(int damage)
    {

    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        ChangeHealth?.Invoke(_currentHealth,_health);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public int Money { get; private set; }

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    //public void OnEnemyDied(int reward)
    //{
    //    Money += reward;
    //}

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
}

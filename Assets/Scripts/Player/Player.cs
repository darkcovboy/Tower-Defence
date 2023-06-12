using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public int Money { get; private set; }

    private void Start()
    {
        _currentHealth = _health;
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}

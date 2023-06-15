using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Warrior : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public event UnityAction<int,int> ChangeHealth;

    private void Start()
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

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        ChangeHealth?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}

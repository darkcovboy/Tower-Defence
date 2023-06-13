using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] private int _health;

    private void Update()
    {
        if (gameObject == null)
        {
            return;
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
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

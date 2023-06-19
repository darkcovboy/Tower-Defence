using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerTransition : Transitions
{
    [SerializeField] private Warrior _warrior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy.CurrentHealth > 0 && _warrior.Enemy == null)
            {
                _warrior.Init(enemy);
                NeedTransit = true;
            Debug.Log("триггер");
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy.CurrentHealth > 0 && _warrior.Enemy == null)
        {
            Debug.Log("переключаюсь");
            _warrior.Init(enemy);
            NeedTransit = true;
        }
        else
        {
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerTransition : Transitions
{
    [SerializeField] private Warrior _warrior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("Something" + _warrior.Battle);
            if (_warrior.Battle == false)
            {
                if (enemy.CurrentHealth > 0 && _warrior.Enemy == null)
                {
                    _warrior.Init(enemy);
                    transform.forward = enemy.transform.position;
                    NeedTransit = true;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}

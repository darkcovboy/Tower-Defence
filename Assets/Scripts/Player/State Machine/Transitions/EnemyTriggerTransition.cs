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
            Debug.Log("коснулся");

            //if (_warrior.Battle == false)
            //{
            //    Debug.Log(_warrior.Battle);

                if (enemy.CurrentHealth > 0 && _warrior.Enemy == null)
                {
                    Debug.Log("стадия");
                    _warrior.Init(enemy);
                    transform.forward = enemy.transform.position;
                    NeedTransit = true;
                }
                else
                {
                    return;
                }
            //}
            //else
            //{
            //    return;
            //}
        }
    }
}

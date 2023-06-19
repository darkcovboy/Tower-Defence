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
                Debug.Log("таргет есть щас");
                return;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();

    //    if (_warrior.HaveEnemy)
    //    {
    //        if (enemy.CurrentHealth > 0 && _warrior.Enemy == null)
    //        {
    //            Debug.Log("переключаюсь");
    //            _warrior.Init(enemy);
    //            NeedTransit = true;
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("стоит враг тут ");
    //        return;
    //    }
    //}
}

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
            _warrior.Init(enemy);
            NeedTransit = true;
        }
    }
}

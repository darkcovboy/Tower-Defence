using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchWarriorTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Warrior>())
        {
            Warrior warrior = other.GetComponent<Warrior>();
            _enemy.Init(warrior);
            NeedTransit = true;
        }
    }
}

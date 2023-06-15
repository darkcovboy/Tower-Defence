using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWarriorTransition : Transitions
{
    [SerializeField] private Warrior _warrior;

    private void Update()
    {
        if (_warrior.CurrentHealth <= 0)
        {
            _warrior.Die();
            NeedTransit = true;
        }
    }
}

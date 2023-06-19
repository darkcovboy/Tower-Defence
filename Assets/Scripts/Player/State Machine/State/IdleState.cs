using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private WarriorAnimations _warriorAnimations;

    private void Update()
    {
        _warriorAnimations.IdleAnimation(true);
    }
}

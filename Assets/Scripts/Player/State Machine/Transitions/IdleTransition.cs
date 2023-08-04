using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transitions
{
    [SerializeField] private WarriorMoveState _warriorMoveState;

    private void Update()
    {
        if (_warriorMoveState == null)
        {
            NeedTransit = true;
        }
        else
        {
            if (Vector3.Distance(transform.position, _warriorMoveState.TargetPosition.position) <= 0.4f)
            {
                NeedTransit = true;
            }
        }
    }
}

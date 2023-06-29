using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMoveTransitions : Transitions
{
    [SerializeField]private WarriorMoveState _warriorMoveState;

    private Transform _target;
    private WarriorAnimations _warriorAnimations;

    private void Start()
    {
        _target = _warriorMoveState.TargetPosition;
        _warriorAnimations = GetComponent<WarriorAnimations>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) > 0.1)
        {
            _warriorAnimations.IdleAnimation(false);
            NeedTransit = true;
        }
    }
}

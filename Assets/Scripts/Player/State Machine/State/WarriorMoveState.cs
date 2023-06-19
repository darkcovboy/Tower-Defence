using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMoveState : State
{
    [SerializeField] private float _speed;
    //[SerializeField] private WarriorAnimations _warriorAnimations;
    [SerializeField]private Transform _targetPosition;

    public Transform TargetPosition => _targetPosition;

    private void Update()
    {
        Vector3 direction = _targetPosition.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        //transform.forward = direction;

        //if (Vector3.Distance(transform.position, _targetPosition.position) <= 0.4f)
        //{
        //    _warriorAnimations.IdleAnimation(true);
        //}
        //else
        //{
        //    _warriorAnimations.IdleAnimation(false);
        //}
    }
}

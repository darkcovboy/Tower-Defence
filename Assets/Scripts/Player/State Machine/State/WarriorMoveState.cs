using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField]private Transform _targetPosition;

    public Transform TargetPosition => _targetPosition;

    private void Update()
    {
        Vector3 direction = _targetPosition.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }
}

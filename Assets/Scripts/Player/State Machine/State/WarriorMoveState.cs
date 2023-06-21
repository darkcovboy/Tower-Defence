using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMoveState : State
{
    [SerializeField] private float _speed;

    public Transform TargetPosition { get; set; }

    private void Update()
    {
        Vector3 direction = TargetPosition.position - transform.position;
        transform.LookAt(TargetPosition);
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverState : State
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private DistanceTransitions _distanceTransitions;

    private Transform _target;
    private int _wavePointIndex = 0;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = rotation;
        transform.forward = direction;

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    //public void Init(Player target,Warrior warrior)
    //{
    //    _target = target.transform;
    //}

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.points.Length - 1)
        {
            return;
        }

        _wavePointIndex++;
        _target = Waypoints.points[_wavePointIndex];
    }
}

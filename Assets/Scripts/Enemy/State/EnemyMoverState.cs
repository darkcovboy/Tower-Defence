using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverState : State
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Waypoints _waypoints;

    private Transform _target;
    private int _wavePointIndex = 0;

    private void Awake()
    {
        _waypoints = FindObjectOfType<Waypoints>();
    }

    private void Start()
    {
        var numberArrayWaypoints = Random.Range(0, 2);

        if (numberArrayWaypoints == 0)
        {
            _target = _waypoints.Points[0];
        }
        else
        {
            _target = _waypoints.Points1[0];
        }
        //_target = Waypoints.points[0];
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

    private void GetNextWaypoint()
    {
        var indexArray = Random.Range(0, 2);
        //if (_wavePointIndex >= Waypoints.points.Length - 1)
        if(_wavePointIndex>=_waypoints.Points.Length-1|| _wavePointIndex >= _waypoints.Points1.Length-1)
        {
            return;
        }

        _wavePointIndex++;

        if(indexArray==0)
        {
            _target = _waypoints.Points[_wavePointIndex];
        }
        else
        {
            _target = _waypoints.Points1[_wavePointIndex];
        }
        //_target = Waypoints.points[_wavePointIndex];
    }
}

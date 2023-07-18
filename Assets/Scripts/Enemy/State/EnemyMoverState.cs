using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverState : State
{
    [SerializeField] private Waypoints _waypoints;

    private Transform _target;
    private int _wavePointIndex = 0;
    private Enemy _enemy;

    private void Awake()
    {
        _waypoints = FindObjectOfType<Waypoints>();
        _enemy = gameObject.GetComponent<Enemy>();
    }

    private void Start()
    {
        if (_enemy.Index == 0)
        {
            _target = _waypoints.Points[0];
        }
        else
        {
            _target = _waypoints.Points1[0];
        }
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);
        //transform.forward = direction;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _enemy.Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        var indexArray = Random.Range(0, 2);

        if (_wavePointIndex >= _waypoints.Points.Length - 1 || _wavePointIndex >= _waypoints.Points1.Length - 1)
        {
            return;
        }

        _wavePointIndex++;

        if (_enemy.Index == 0)
        {
            if (indexArray == 0)
            {
                _target = _waypoints.Points[_wavePointIndex];

            }
            else
            {
                _target = _waypoints.Points2[_wavePointIndex];
            }
        }
        else
        {
            if (indexArray == 0)
            {
                _target = _waypoints.Points1[_wavePointIndex];
            }
            else
                _target = _waypoints.Points3[_wavePointIndex];
        }
    }
}

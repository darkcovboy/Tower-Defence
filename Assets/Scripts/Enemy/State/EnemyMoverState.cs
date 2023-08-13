using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverState : State
{
    [SerializeField] private Waypoints _waypoints;

    private Transform _target;
    private int _wavePointIndex = 0;
    private Enemy _enemy;
    private Vector3 _startPosition;

    private readonly float _distanceBetweenTarget = 0.4f;

    private void Awake()
    {
        _waypoints = FindObjectOfType<Waypoints>();
        _enemy = gameObject.GetComponent<Enemy>();
    }

    private void Start()
    {
        _startPosition = transform.position;
        ChooseWaypoint();
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _enemy.Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) <= _distanceBetweenTarget)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= _waypoints.Points.Length - 1 || _wavePointIndex >= _waypoints.Points1.Length - 1)
        {
            return;
        }

        bool indexArray = Random.value > 0.5f;

        _wavePointIndex++;

        if (_enemy.Index == 0)
        {
            if (indexArray)
                _target = _waypoints.Points[_wavePointIndex];
            else
                _target = _waypoints.Points2[_wavePointIndex];
        }
        else
        {
            if (indexArray)
                _target = _waypoints.Points1[_wavePointIndex];
            else
                _target = _waypoints.Points3[_wavePointIndex];
        }
    }

    public void ResetWaypoint()
    {
        transform.position = _startPosition;
        _wavePointIndex = 0;
        ChooseWaypoint();
    }

    private void ChooseWaypoint()
    {
        if (_enemy.Index == 0)
            _target = _waypoints.Points[0];
        else
            _target = _waypoints.Points1[0];
    }
}

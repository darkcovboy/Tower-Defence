using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _health = 10f;

    public float Health => _health;

    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        //_target = Waypoints.points[0];
    }

    private void Update()
    {
       /* Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime,Space.World);
        //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = rotation;
        transform.forward = direction;

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
       */
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        _wavePointIndex++;
        _target = Waypoints.points[_wavePointIndex];
    }
}

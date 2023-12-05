using System.Linq;
using UnityEngine;

public class EnemyMoverState : State
{
    private const float Offset = 2.0f;

    private Vector3 _target;
    private Waypoints _waypoints;
    private int _wavePointIndex = 0;
    private Enemy _enemy;
    private Vector3 _startPosition;

    private readonly float _distanceBetweenTarget = 0.4f;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void Init(Waypoints waypoints)
    {
        _waypoints = waypoints;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _target = _waypoints.Points[0].position;
    }

    private void Update()
    {
        Vector3 direction = _target - transform.position;
        transform.Translate(direction.normalized * _enemy.Speed * Time.deltaTime, Space.World);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _enemy.Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target) <= _distanceBetweenTarget)
            GetNextWaypoint();
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= _waypoints.Points.Count() - 1)
        {
            return;
        }

        _wavePointIndex++;

        float randomOffsetX = Random.Range(-Offset, Offset);
        float randomOffsetZ = Random.Range(-Offset, Offset);

        Vector3 newPosition = _waypoints.Points[_wavePointIndex].position + new Vector3(randomOffsetX, 0f, randomOffsetZ);
        _target = newPosition;
    }

    public void ResetWaypoint()
    {
        transform.position = _startPosition;
        _wavePointIndex = 0;
        _target = _waypoints.Points[0].position;
    }
}

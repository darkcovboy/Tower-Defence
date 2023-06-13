using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBall : MonoBehaviour
{
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _target;
    [SerializeField] private float _angleDegrees;
    [SerializeField] private GameObject _ball;

    private float g = Physics.gravity.y;

    private void Update()
    {
        _spawnTransform.localEulerAngles = new Vector3(-_angleDegrees, 0f, 0f);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 fromTo = _target.position - transform.position;
        Vector3 FromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.LookAt(_target);

        float x = FromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = _angleDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        var gameObject = Instantiate(_ball, _spawnTransform.position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().velocity = _spawnTransform.forward * v;
    }
}

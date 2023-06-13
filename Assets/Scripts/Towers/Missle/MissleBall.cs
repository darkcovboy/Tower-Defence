using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBall : Missle
{
    [SerializeField] private float _angleDegrees;
    [SerializeField] private float _radius;

    private Transform _firstEnemyMeet;
    private Transform _startTransform;
    private readonly float g = Physics.gravity.y;

    protected override IEnumerator MoveToTarget()
    {
        BallPhysics();

        Debug.Log("Something");

        while (Vector3.Distance(transform.position, _firstEnemyMeet.transform.position) > DistanceBetweenTarget)
        {
            Debug.Log("Something 555");
            yield return null;
        }

        ExploseDamage();
        gameObject.SetActive(false);
    }

    public override void Create(Transform target, Enemy enemy, int damage)
    {
        Target = target;
        Damage = damage;
        Enemy = enemy;
        _startTransform = transform;
        _firstEnemyMeet = Target.transform;
        StartCoroutine(MoveToTarget());
    }

    private void ExploseDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);

        foreach(var hitCollider in hitColliders)
        {
            if(hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(Damage, Type);
            }
        }
    }

    private void BallPhysics()
    {
        Vector3 fromTo = _firstEnemyMeet.position - transform.position;
        Vector3 FromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        float x = FromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = _angleDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        gameObject.GetComponent<Rigidbody>().velocity = _startTransform.forward * v;
    }
}

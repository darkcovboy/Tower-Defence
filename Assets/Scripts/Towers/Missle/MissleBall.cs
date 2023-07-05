using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBall : Missle
{
    [SerializeField] private float _angleDegrees;
    [SerializeField] private float _radius;
    [SerializeField] private float _maxDistance;
    [SerializeField] private ParticleSystem _afterExploseParticle;

    private Transform _firstEnemyMeet;
    private Transform _startTransform;
    private readonly float g = Physics.gravity.y;

    private void OnDisable()
    {
        StopCoroutine(DisableObject());
    }

    protected override IEnumerator MoveToTarget()
    {
        BallPhysics();

        while (Vector3.Distance(transform.position, Target.transform.position) > MissleData.DistanceBetweenTarget)
        {
            if (Vector3.Distance(transform.position, _firstEnemyMeet.transform.position) > _maxDistance)
                break;
            yield return null;
        }

        ExploseDamage();
        StartCoroutine(DisableObject());
    }

    private IEnumerator DisableObject()
    {
        _afterExploseParticle.Play();
        yield return new WaitForSeconds(0.5f);
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
        Vector3 fromTo = _firstEnemyMeet.position - gameObject.transform.parent.transform.position;
        Vector3 FromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        gameObject.transform.parent.transform.LookAt(Target);

        float x = FromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = _angleDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.parent.transform.forward * v * MissleData.Speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Fire,
    Ice,
    Physical
}

public class Missle : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float DistanceBetweenTarget;

    public DamageType Type;

    protected int Damage;
    protected Transform Target;
    protected Enemy Enemy;

    private void OnDisable()
    {
        StopCoroutine(MoveToTarget());
    }

    protected virtual IEnumerator MoveToTarget()
    {
        while(Vector3.Distance(transform.position, Target.position) > DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * Speed);
            yield return null;
        }

        Enemy.TakeDamage(Damage, Type);
        gameObject.SetActive(false);
    }

    public virtual void Create(Transform target,Enemy enemy, int damage)
    {
        Target = target;
        Damage = damage;
        Enemy = enemy;
        StartCoroutine(MoveToTarget());
    }
}

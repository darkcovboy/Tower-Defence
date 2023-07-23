using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Missle : MonoBehaviour
{
    [SerializeField] protected MissleData MissleData;

    public DamageType Type => MissleData.DamageType;

    protected int Damage;
    protected Transform Target;
    protected Enemy Enemy;
    protected int Level = 0;

    private void OnDisable()
    {
        StopCoroutine(MoveToTarget());
    }

    protected virtual IEnumerator MoveToTarget()
    {
        while(Vector3.Distance(transform.position, Target.position) > MissleData.DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * MissleData.Speed);
            yield return null;
        }

        Enemy.TakeDamage(Damage, Type);
        gameObject.SetActive(false);
    }

    public virtual void Create(Transform target,Enemy enemy, int damage, int level)
    {
        Target = target;
        Damage = damage;
        Enemy = enemy;
        StartCoroutine(MoveToTarget());
    }
}

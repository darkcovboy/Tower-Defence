using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleFire : Missle
{
    [SerializeField] private FireEffectData _effectData;

    protected override IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, Target.position) > MissleData.DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * MissleData.Speed);
            yield return null;
        }

        Enemy.TakeDamage(Damage, Type, _effectData.BurnDamage[Level], _effectData.BurnRates[Level]);
        gameObject.SetActive(false);
    }
}

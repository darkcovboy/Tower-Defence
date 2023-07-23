using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleIce : Missle
{
    [SerializeField] private IceEffectData _effectData;

    protected override IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, Target.position) > MissleData.DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * MissleData.Speed);
            yield return null;
        }

        Enemy.TakeDamage(Damage, Type, _effectData.IceSlowDownPercentage[Level], _effectData.IceRates[Level]);
        gameObject.SetActive(false);
    }
}

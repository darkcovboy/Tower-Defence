using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLightning : Missle
{
    [SerializeField] private float _radius;
    [SerializeField] private LightningData _lightningData;

    private LightningEffect _lightningEffect;

    private void Start()
    {
        _lightningEffect.Deactivate();
    }

    protected override IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, Target.position) > MissleData.DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * MissleData.Speed);
            yield return null;
        }

        Enemy.TakeDamage(Damage, Type);
        _lightningEffect.Activate();
        _lightningEffect.TakeEnemies(FindEnemies(), MissleData.DamageType, _lightningData.MaxEnemies[Level], _lightningData.LightningRates[Level], _lightningData.LightningDamages[Level]);
        gameObject.SetActive(false);
    }

    public void Create(Transform target, Enemy enemy, int damage, int level, LightningEffect lightningEffect)
    {
        _lightningEffect = lightningEffect;
        base.Create(target, enemy, damage, level);
    }

    private List<Enemy> FindEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, 1, QueryTriggerInteraction.Collide);
        List<Enemy> enemies = new List<Enemy>();

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemies.Add(enemy);
            }
        }

        return enemies;
    }
}

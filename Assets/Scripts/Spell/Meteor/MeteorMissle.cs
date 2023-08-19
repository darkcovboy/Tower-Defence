using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class MeteorMissle : Missle
{
    [SerializeField] private ParticleSystem _afterExploseParticle;
    [SerializeField] private int _radius;

    private readonly string _audioKey = "Meteor";
    private Vector3 endPosition;

    private void OnDisable()
    {
        StopCoroutine(DisableObject());
    }

    public void Create(Vector3 target, int damage)
    {
        endPosition = target;
        Damage = damage;
        StartCoroutine(MoveToTarget());
    }

    protected override IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, endPosition) > MissleData.DistanceBetweenTarget)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * MissleData.Speed);
            yield return null;
        }

        ExploseDamage();
        StartCoroutine(DisableObject());
    }

    private IEnumerator DisableObject()
    {
        if (TryGetComponent<SourceAudio>(out SourceAudio audio))
        {
            audio.Play(_audioKey);
        }
        _afterExploseParticle.Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.Deactivate();
    }

    private void ExploseDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, 1, QueryTriggerInteraction.Collide);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(Damage, Type);
            }
        }
    }
}

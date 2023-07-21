using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MeteorShoot : Spell
{
    [SerializeField] MeteorSpawner _meteorSpawner;
    [SerializeField] private int _damage;
    [SerializeField] private int _meteorsCount;
    [SerializeField] private float _meteorsDelay;

    protected override IEnumerator MakeAction(Vector3 endPosition)
    {
        for (int i = 0; i < _meteorsCount; i++)
        {
            _meteorSpawner.PushMissle(gameObject.transform, endPosition, _damage);

            yield return new WaitForSeconds(_meteorsDelay);
        }
    }
}

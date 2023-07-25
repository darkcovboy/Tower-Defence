using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MeteorShoot : Spell
{
    [SerializeField] private float _yPosition;
    [SerializeField] MeteorSpawner _meteorSpawner;
    [SerializeField] private int _damage;
    [SerializeField] private int _meteorsCount;
    [SerializeField] private float _meteorsDelay;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, _yPosition, transform.position.z);
    }

    protected override IEnumerator MakeAction(Vector3 endPosition)
    {
        var newPosition = new Vector3(endPosition.x, transform.position.y, endPosition.z);
        transform.position = newPosition;

        for (int i = 0; i < _meteorsCount; i++)
        {
            _meteorSpawner.PushMissle(gameObject.transform, endPosition, _damage);

            yield return new WaitForSeconds(_meteorsDelay);
        }
    }
}

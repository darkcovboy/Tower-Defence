using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WarriorsCreator : Spell
{
    [SerializeField] private WarriorCreatorSpawner _spawner;
    [SerializeField] private GameObject _pointsPrefab;
    [SerializeField] private int _warriorsNumber;
    [SerializeField] private int _secondsToLive;

    private void Start()
    {
        if (_pointsPrefab.transform.childCount != _warriorsNumber)
            throw new Exception();
    }

    protected override IEnumerator MakeAction(Vector3 endPosition)
    {
        var newPoints = Instantiate(_pointsPrefab, endPosition, Quaternion.identity);

        for (int i = 0; i < _warriorsNumber; i++)
        {
            _spawner.PushWarrior(newPoints.transform.GetChild(i).transform.position, _secondsToLive);
            yield return null;
        }
    }
}

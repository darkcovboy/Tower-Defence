using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WarriorsCreator : Spell
{
    [SerializeField] private WarriorCreatorSpawner _spawner;
    [SerializeField] private Transform _points;
    [SerializeField] private int _warriorsNumber;
    [SerializeField] private int _secondsToLive;

    private List<GameObject> _warriors;

    private void Start()
    {
        if (_points.childCount != _warriorsNumber)
            throw new Exception();
    }

    protected override IEnumerator MakeAction(Vector3 endPosition)
    {
        var newPoints = Instantiate(_points);
        newPoints.position = endPosition;

        for (int i = 0; i < _warriorsNumber; i++)
        {
            _spawner.PushWarrior(newPoints.GetChild(i).transform, _secondsToLive);
            yield return null;
        }
    }
}

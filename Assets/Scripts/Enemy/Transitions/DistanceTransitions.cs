using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransitions : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    public bool Flag { get; set; }

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeedTransit = true;
        }

        if (Vector3.Distance(transform.position, Warrior.transform.position) <= 1)
        {
            NeedTransit = true;
            Flag = true;
        }
        else
            Flag = false;
    }
}

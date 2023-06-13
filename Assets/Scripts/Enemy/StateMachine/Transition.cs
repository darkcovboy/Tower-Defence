using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }
    protected Warrior Warrior { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target ,Warrior warrior)
    {
        Target = target;
        Warrior = warrior;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

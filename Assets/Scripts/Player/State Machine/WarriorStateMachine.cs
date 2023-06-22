using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Warrior))]
public class WarriorStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Enemy _enemy;
    private Player _target;
    private Warrior _warrior;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void OnEnable()
    {
        Debug.Log("Something");
        Reset(_firstState);
    }

    public void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}

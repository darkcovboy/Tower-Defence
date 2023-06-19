using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWarriorState : State
{
    [SerializeField] WarriorStateMachine stateMachine;
    [SerializeField] private State _firstState;
    private WarriorAnimations _warriorAnimations;
    private Coroutine _coroutine;

    private void Awake()
    {
        _warriorAnimations = GetComponent<WarriorAnimations>();
    }

    private void OnEnable()
    {
        _warriorAnimations.DieAnimation(true);

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(Die());

        //gameObject.SetActive(false);
        //Destroy(gameObject, 3f);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _warriorAnimations.DieAnimation(false);

        enabled = false;
    }

    public IEnumerator Die()
    {
        var WaitForSeconds = new WaitForSeconds(3f);
        yield return WaitForSeconds;
        gameObject.SetActive(false);
    }
}

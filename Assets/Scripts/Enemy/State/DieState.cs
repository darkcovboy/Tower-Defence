using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Death");
        //StartCoroutine(ActiveSelfOff());
        Destroy(gameObject,3f);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    //IEnumerator ActiveSelfOff()
    //{
    //    yield return new WaitForSeconds(3f);
    //    //gameObject.SetActive(false);
    //    Destroy(gameObject);
    //}
}


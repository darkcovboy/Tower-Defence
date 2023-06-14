using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_enemy.Warrior.gameObject.activeSelf==false)
        {
            _animator.Play("Run");
            NeedTransit = true;
        }
    }
}
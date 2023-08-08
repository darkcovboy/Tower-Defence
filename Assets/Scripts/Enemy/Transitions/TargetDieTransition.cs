using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transitions
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.Dying += TargetDie;
    }

    private void OnDisable()
    {
        _player.Dying -= TargetDie;
    }

    private void TargetDie()
    {
        NeedTransit = true;
    }

    //private void Update()
    //{
    //    if (Target.gameObject.activeSelf == false)
    //    {
    //        NeedTransit = true;
    //    }
    //}
}

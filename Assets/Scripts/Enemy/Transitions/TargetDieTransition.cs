using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transitions
{
    private Player _player;
    protected override void OnEnable()
    {
        base.OnEnable();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(_player.CurrentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}

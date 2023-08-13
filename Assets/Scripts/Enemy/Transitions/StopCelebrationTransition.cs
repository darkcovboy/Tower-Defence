using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCelebrationTransition : Transitions
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    //[SerializeField] private CelebrationState _celebration;

    protected override void OnEnable()
    {
        base.OnEnable();
        _player = Target.GetComponent<Player>();
    }

    private void Update()
    {
        if(_player.CurrentHealth > 0)
        {
            NeedTransit = true;
        }
    }
}

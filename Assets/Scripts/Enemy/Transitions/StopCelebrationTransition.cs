using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCelebrationTransition : Transitions
{ 
    [SerializeField] private Enemy _enemy;

    private Player _player;

    protected override void OnEnable()
    {
        base.OnEnable();
        _player = _enemy.Target;
    }

    private void Update()
    {
        if(_player.CurrentHealth > 0)
        {
            if (_enemy.Boss == true)
            {
                _enemy.GetComponent<EnemyMoverState>().ResetWaypoint();
                _enemy.GetComponent<EnemyAnimations>().AttackAnimation(false);
                _enemy.GetComponent<AttackState>().ResetAttackTime();
            }
            NeedTransit = true;
        }
    }
}

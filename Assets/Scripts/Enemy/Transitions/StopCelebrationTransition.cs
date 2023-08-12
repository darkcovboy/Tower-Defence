using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCelebrationTransition : Transitions
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    //[SerializeField] private CelebrationState _celebration;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _player.ExtraLive += PlayExtraLive;
    }

    private void OnDisable()
    {
        _player.ExtraLive -= PlayExtraLive;
    }

    private void Update()
    {
        //_player.
        //    if (_player.CurrentHealth > 0)
        //    {
        //        NeedTransit = true;
        //        //_celebration.enabled = false;
        //        //this.enabled = false;
        //    }

        if(_player != null & _player.CurrentHealth > 0)
        {
            Debug.Log("Go");
            NeedTransit = true;
        }
    }

    public void PlayExtraLive()
    {
        //_enemy.GetComponent<EnemyMoverState>().ResetWaypoint();
        //_enemy.GetComponent<EnemyMoverState>().enabled = true;
        //NeedTransit = true;
    }
}

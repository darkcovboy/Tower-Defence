using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private EnemyMoverState _enemyMoverState;

    private Player _target;

    public event UnityAction Dying;

    public Player Target => _target;
    public int Health => _health;

    public void TakeDamage(int damage, Type damageType)
    {
        _health -= damage;

        int i = (int)damageType;

        switch(i)
        {
            case 0:
                //Добавить корутины чуть позже
                break;
            case 1:
                break;
            case 2:
                break;
        }

        if(_health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }

}

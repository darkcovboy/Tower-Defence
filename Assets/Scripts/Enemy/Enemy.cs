using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    public event UnityAction Dying;

    public Player Target => _target;
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Init(Player target)
    {
        _target = target;
    }
}

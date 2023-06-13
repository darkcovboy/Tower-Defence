using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;
    private Warrior _warrior;

    public event UnityAction Dying;

    public Player Target => _target;
    public Warrior Warrior => _warrior;
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Init(Player target,Warrior warrior)
    {
        _target = target;
        _warrior = warrior;
    }
}

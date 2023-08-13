using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;

    private const string _attack = "Attack";
    private const string _death = "Death";
    private const string _celebration = "Celebration";

    private void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    public void RunAnimation(bool flag)
    {
        _animator.SetBool("Run", flag);
    }

    public void AttackAnimation(bool flag)
    {
        _animator.SetBool(_attack, flag);
    }

    public void DeathAnimation(bool flag)
    {
        _animator.SetBool(_death, flag);
    }

    public void CelebrationAnimation(bool flag)
    {
        _animator.SetBool(_celebration, flag);
    }
}

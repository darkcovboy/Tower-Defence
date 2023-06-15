using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WarriorAnimations : MonoBehaviour
{
    private Animator _animator;

    const string Attack = "Attack";
    const string Death = "Death";
    const string Celebration = "Celebration";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnimation(bool flag)
    {
        _animator.SetBool(Attack, flag);
    }

    public void DieAnimation(bool flag)
    {
        _animator.SetBool(Death, flag);
    }

    private void CelebrationAnimation(bool flag)
    {
        _animator.SetBool(Celebration, flag);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Fire,
    Ice,
    Physical,
    Lightning
}

public class MissleData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceBetweenTarget;
    [SerializeField] private DamageType _damageType;

    public float Speed => _speed;
    public float DistanceBetweenTarget => _distanceBetweenTarget;
    public DamageType DamageType => _damageType;
}

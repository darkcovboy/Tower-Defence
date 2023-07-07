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
    public float Speed;
    public float DistanceBetweenTarget;
    public DamageType DamageType;
}

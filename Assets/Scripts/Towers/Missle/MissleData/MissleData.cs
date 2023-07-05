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

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower Data")]
public class MissleData : ScriptableObject
{
    public float Speed;
    public float DistanceBetweenTarget;
    public DamageType DamageType;
}

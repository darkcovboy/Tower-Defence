using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "Warrior")]
public class WarriorData : ScriptableObject
{
    [SerializeField] private int[] _healthWarriors;

    public int[] HealthWarriors { get { return _healthWarriors; } }
}

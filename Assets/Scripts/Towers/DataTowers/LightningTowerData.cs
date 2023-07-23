using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTowerData : TowerData
{
    [Header("Lightning Abilities")]
    [SerializeField] private int[] _maxTargets;
    [SerializeField] private int[] _lightningRate;
    [SerializeField] private int[] _lightningDamage;

    public int[] MaxTargets => _maxTargets;
    public int[] LightningRate => _lightningRate;
    public int[] LightningDamage => _lightningDamage;
}

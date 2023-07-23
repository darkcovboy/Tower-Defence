using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMageData : TowerData
{
    [Header("Fire Abilities")]
    [SerializeField] private int[] _burnRates;
    [SerializeField, Range(0, 1)] private float[] _burnDamage;
    [SerializeField] private GameObject _fireEffectPrefab;

    public int[] BurnRates => _burnRates;
    public float[] BurnDamages => _burnDamage;
    public GameObject FireEffectPrefab => _fireEffectPrefab;
}

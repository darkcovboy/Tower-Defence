using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMageData : TowerData
{
    [Header("Ice Abilities")]
    [SerializeField] private int[] _iceRates;
    [SerializeField, Range(0, 1)] private float[] _iceSlowdownPercentage;
    [SerializeField] private GameObject _iceEffectPrefab;

    public int[] IceRates => _iceRates;
    public float[] IceSlowdownPercentage => _iceSlowdownPercentage;
    public GameObject IceEffectPrefab => _iceEffectPrefab;
}

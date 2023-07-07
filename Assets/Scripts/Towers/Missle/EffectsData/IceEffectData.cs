using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Effect", menuName = "Ice data")]
public class IceEffectData : ScriptableObject
{
    [SerializeField] private int _iceRates;
    [Range(0, 1)]
    [SerializeField] private float _iceSlowDownPercentage;
    [SerializeField] private GameObject _iceEffect;

    public int IceRates => _iceRates;
    public float IceSlowDownPercentage => _iceSlowDownPercentage;
    public GameObject IceEffect => _iceEffect;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lightning", menuName = "Config")]
public class LightningData : ScriptableObject
{
    [SerializeField, Min(1)] private int _lightningRate;
    [SerializeField] private float _lightningDamageMultiplier;
    [SerializeField] private GameObject _lightningEffect;

    public int LightningRate => _lightningRate;
    public GameObject LightningEffect => _lightningEffect;

    public float LightningDamageMultiplier => _lightningDamageMultiplier;
}

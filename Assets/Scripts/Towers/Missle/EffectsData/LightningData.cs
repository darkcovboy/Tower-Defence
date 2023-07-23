using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Lightning", menuName = "Lightning")]
public class LightningData : ScriptableObject
{
    [SerializeField, Min(1)] int[] _maxEnemies;
    [SerializeField] int[] _lightningRates;
    [SerializeField] int[] _lightningDamages;

    public int[] MaxEnemies => _maxEnemies;
    public int[] LightningRates => _lightningRates;
    public int[] LightningDamages => _lightningDamages;
}

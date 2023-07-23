using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectData : ScriptableObject
{
    [SerializeField] private int[] _burnRates;
    [SerializeField] private int[] _burnDamage;

    public int[] BurnRates => _burnRates;
    public int[] BurnDamage => _burnDamage;
}

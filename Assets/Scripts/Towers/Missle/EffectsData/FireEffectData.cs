using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Effect", menuName = "Fire data")]
public class FireEffectData : ScriptableObject
{
    [SerializeField] private int _burnRates;
    [SerializeField] private int _burnDamage;
    [SerializeField] private GameObject _fireEffect;

    public int BurnRates => _burnRates;
    public int BurnDamage => _burnDamage;

    public GameObject FireEffect => _fireEffect;
}

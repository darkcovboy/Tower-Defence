using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Header("Basic parameters")]
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;
    [SerializeField, Min(1)] private float _speed;
    [Header("Effects")]
    [SerializeField] private IceEffectData _iceData;
    [SerializeField] private FireEffectData _fireData;
    [SerializeField] private LightningData _lightningData;

    [Header("Resistance")]
    [SerializeField, Range(0, 1)] private float _physicalResistace;
    [SerializeField, Range(0, 1)] private float _fireResistace;
    [SerializeField, Range(0, 1)] private float _iceResistace;
    [SerializeField, Range(0, 1)] private float _lightningResistace;

    public int Health => _health;
    public int Reward => _reward;
    public int Damage => _damage;
    public float Speed => _speed;
    public IceEffectData IceEffectData => _iceData;
    public FireEffectData FireEffectData => _fireData;
    public LightningData LightningData => _lightningData;
    public float PhysicalResistace => _physicalResistace;
    public float FireResistace => _fireResistace;
    public float IceResisnace => _iceResistace;
    public float LightningResistace => _lightningResistace;

}

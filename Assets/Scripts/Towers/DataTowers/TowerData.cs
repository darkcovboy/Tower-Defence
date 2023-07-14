using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;
public enum TowerType
{
    Archer,
    Canon,
    IceMage,
    FireMage,
    Barracks,
    LightningMage
}

public class TowerData : ScriptableObject
{
    public List<int> Costs;
    public int BuyCost;
    public List<int> Damages;
    public List<float> Delays;
    public TowerType TowerType;
    [Range(10, 30)] public int Radius;

    [Header("Information")]
    [SerializeField] private LeanPhrase _titleLocalized;
    [SerializeField] private LeanPhrase _descriptionLocalized;

    public LeanPhrase Title => _titleLocalized;
    public LeanPhrase Description => _descriptionLocalized;
}

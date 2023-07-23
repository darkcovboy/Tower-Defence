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
    [Header("Base information")]
    [SerializeField] private List<int> _costs;
    [SerializeField] private int _buyCost;
    [SerializeField] private List<int> _damages;
    [SerializeField] private List<float> _delays;
    [SerializeField] private TowerType _towerType;
    [SerializeField, Range(10, 50)] private List<int> _radius;

    [Header("UI Information")]
    [SerializeField] private LeanPhrase _titleLocalized;
    [SerializeField] private LeanPhrase _descriptionLocalized;

    public List<int> Costs => _costs;
    public int BuyCost => _buyCost;
    public List<int> Damages => _damages;
    public List<float> Delays => _delays;
    public TowerType TowerType => _towerType;
    public List<int> Radiuses => _radius;
    public LeanPhrase Title => _titleLocalized;
    public LeanPhrase Description => _descriptionLocalized;
}

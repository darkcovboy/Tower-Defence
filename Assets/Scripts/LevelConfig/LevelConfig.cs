using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]

public class LevelConfig : ScriptableObject
{
    [Header("Start Settings")]
    [SerializeField] private float _time;
    [SerializeField] private int _startMoney;
    [SerializeField] private int _startHealth;
    [SerializeField, Range(0,3)] private int _maxLevel;
    [SerializeField] private bool _isFireOpened;
    [SerializeField] private bool _isIceOpened;
    [SerializeField] private bool _isLightningOpened;
    [Header("Ad Settings")]
    [SerializeField] private int _adHealth;
    [SerializeField] private int _adStartMoney;
    [Header("Spell Settings")]
    [SerializeField] private bool _isOpenedMeteor;
    [SerializeField] private bool _isOpenedWarriorCreator;
    [Header("Points coefficients")]
    [SerializeField, Range(0, 1)] private float _healthCoefficient;
    [SerializeField, Range(0, 1)] private float _timeCoefficient;
    [SerializeField, Range(0, 1)] private float _moneyCoefficient;
    [Header("Result Settings")]
    [SerializeField] private List<int> _healthStars;
    public float Time => _time;

    public float HealthCoefficient => _healthCoefficient;
    public float TimeCoefficient => _timeCoefficient;
    public float MoneyCoefficient => _moneyCoefficient;

    public int StartMoney => _startMoney;
    public int StartHealth => _startHealth;
    public int AdStartMoney => _adStartMoney;
    public int AdHealth => _adHealth;

    public bool IsOpenedMeteor => _isOpenedMeteor;
    public bool IsOpenedWarriorCreator => _isOpenedWarriorCreator;
    public int MaxLevel => _maxLevel;

    public bool IsIceOpened => _isIceOpened;
    public bool IsFireOpened => _isFireOpened;
    public bool IsLightningOpened => _isLightningOpened;

    public IReadOnlyCollection<int> HealthStars => _healthStars.AsReadOnly();
        
}

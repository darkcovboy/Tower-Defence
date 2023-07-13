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
    [SerializeField] private int _adStartMoney;
    [Header("Points coefficients")]
    [SerializeField, Range(0,1)] private float _healthCoefficient;
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

    public IReadOnlyCollection<int> HealthStars => _healthStars.AsReadOnly();
        
}

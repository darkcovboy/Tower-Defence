using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _time;
    [Header("Points coefficients")]
    [SerializeField] private float _healthCoefficient;
    [SerializeField] private float _timeCoefficient;
    [SerializeField] private float _moneyCoefficient;
    public float Time => _time;

    public float HealthCoefficient => _healthCoefficient;
    public float TimeCoefficient => _timeCoefficient;
    public float MoneyCoefficient => _moneyCoefficient;
        
}

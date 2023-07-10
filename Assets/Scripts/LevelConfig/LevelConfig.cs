using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]

public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _time;
    [Header("Points coefficients")]
    [SerializeField, Range(0,1)] private float _healthCoefficient;
    [SerializeField, Range(0, 1)] private float _timeCoefficient;
    [SerializeField, Range(0, 1)] private float _moneyCoefficient;
    public float Time => _time;

    public float HealthCoefficient => _healthCoefficient;
    public float TimeCoefficient => _timeCoefficient;
    public float MoneyCoefficient => _moneyCoefficient;
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPoints
{
    public float Points => _points;
    public float Time => _timer.SpentTime;

    private Timer _timer;
    private float _points;
    private float _coefficientRemainMoney;
    private float _coefficientRemainTime;
    private float _coefficientHealth;

    public CountPoints(Timer timer, float coefficientRemainMoney, float coefficientRemainTime, float coefficientHealth)
    {
        _timer = timer;
        _coefficientRemainMoney = coefficientRemainMoney;
        _coefficientRemainTime = coefficientRemainTime;
        _coefficientHealth = coefficientHealth;
    }

    public float Count(float maxHealth, float currentHealth, float remainMoney)
    {
        float points = (maxHealth - currentHealth) * _coefficientHealth + remainMoney * _coefficientRemainMoney + (_timer.SpentTime) * _coefficientRemainTime;
        return points;
    }
}

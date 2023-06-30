using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private float _money;

    public float Money => _money;

    public void AddMoney(float money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money += money;
    }

    public void TakeMoney(float money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money -= money;
    }
}

using UnityEngine;
using UnityEngine.Events;
using System;
using Zenject;

public class MoneyCounter : IMoneyHandler
{
    [SerializeField] private int _money;

    public float Money => _money;
    public event Action<int> OnMoneyChanged;

    public MoneyCounter(int startMoney)
    {
        _money = startMoney;
        OnMoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money += money;
        OnMoneyChanged?.Invoke(_money);
    }

    public void TakeMoney(int money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money -= money;
        OnMoneyChanged?.Invoke(_money);
    }
}

using UnityEngine;
using UnityEngine.Events;
using System;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private int _money;

    public float Money => _money;
    public event UnityAction<int> MoneyChanged;

    public void Init(int startMoney)
    {
        _money = startMoney;
        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void TakeMoney(int money)
    {
        if (money <= 0)
            throw new ArgumentException();

        _money -= money;
        MoneyChanged?.Invoke(_money);
    }
}

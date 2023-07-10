using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private MoneyCounter _moneyCounter;

    private void OnDisable()
    {
        _moneyCounter.MoneyChanged -= OnMoneyChanged;
    }

    public void Init(MoneyCounter moneyCounter)
    {
        _moneyCounter = moneyCounter;
        _moneyCounter.MoneyChanged += OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}

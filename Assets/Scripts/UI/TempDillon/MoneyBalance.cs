using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private IMoneyHandler _moneyHandler;

    [Inject]
    public void Init(IMoneyHandler moneyCounter)
    {
        _moneyHandler = moneyCounter;
        _moneyHandler.OnMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _moneyHandler.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}

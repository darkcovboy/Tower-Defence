using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private MoneyCounter _moneyCounter;

    private void Awake()
    {
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    private void OnEnable()
    {
        _moneyCounter.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _moneyCounter.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}

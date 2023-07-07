
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Player _player;
    /*

    private void OnEnable()
    {
        _player.MoneyChanged += OnCoinsChange;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnCoinsChange;
    }

    private void OnCoinsChange(int money)
    {
        _moneyText.text = _player.Money.ToString();
    }
    */
}
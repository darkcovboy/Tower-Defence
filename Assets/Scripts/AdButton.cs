using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    
    private int _money;
    private MoneyCounter _moneyCounter;

    public void Init(int money, MoneyCounter moneyCounter)
    {
        _money = money;
        _moneyCounter = moneyCounter;
        _moneyText.text = _money.ToString();
        gameObject.GetComponent<Button>().onClick.AddListener(ShowAD);
    }

    public void ShowAD()
    {
        //Тут какой-то скрипт показа рекламы
        gameObject.Deactivate();
    }
}

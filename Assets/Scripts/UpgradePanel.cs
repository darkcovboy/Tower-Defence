using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField, Range(0, 1)] private float _sellPercent;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;

    private MoneyCounter _moneyCounter;
    private Tower _tower;

    private void Awake()
    {
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    private void Update()
    {
        if (_tower.Cost >= _moneyCounter.Money || _tower.IsMaxLevel == true)
            _upgradeButton.interactable = false;
        else
            _upgradeButton.interactable = true;
    }

    public void TowerChoice(ref Tower tower)
    {
        _tower = tower;
        _costText.text = _tower.Cost.ToString();
    }

    public void Sell()
    {
        _moneyCounter.AddMoney(_sellPercent * _tower.Cost);
        _tower.ResetSettings();
        _tower.Deactivate();
        _spawnPlaceTower.ResetSettings();
    }

    public void Upgrade()
    {
        _moneyCounter.TakeMoney(_tower.Cost);
        _tower.Upgrade();

        if(_tower.IsMaxLevel == true)
        {
            _costText.text = "Max";
        }
        else
        {
            _costText.text = _tower.Cost.ToString();
        }
        
    }
}

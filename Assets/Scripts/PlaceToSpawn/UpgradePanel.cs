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
    [SerializeField] private TextMeshProUGUI _sellText;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;
    [SerializeField] private SpawnPlaceTowerBeaty _spawnPlaceTowerBeaty;
    [SerializeField] private ChooseWarriorTarget _flagButton;

    private MoneyCounter _moneyCounter;
    private Tower _tower;

    private void Awake()
    {
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    private void OnEnable()
    {
        if(_tower.TowerType == TowerType.Barracks)
        {
            _flagButton.Activate();
            BarracksTower barracksTower = (BarracksTower)_tower;
            _flagButton.Init(ref barracksTower);
        }
        else
        {
            _flagButton.Deactivate();
        }
    }

    private void Update()
    {
        if (_tower.Cost >= _moneyCounter.Money || _tower.IsMaxLevel == true)
            _upgradeButton.interactable = false;
        else
            _upgradeButton.interactable = true;
    }

    public void CloseRangeField()
    {
        if(_tower != null)
        {
            if (_tower.TowerType == TowerType.Barracks)
            {
                _flagButton.Close();
            }
        }
    }

    public void TowerChoice(ref Tower tower)
    {
        _tower = tower;
        ChangeText();
    }

    public void Sell()
    {
        _moneyCounter.AddMoney(_sellPercent * _tower.Cost);
        _tower.ResetSettings();
        _tower.Deactivate();
        _spawnPlaceTowerBeaty.PlayParticles();
        _spawnPlaceTower.ResetSettings();
    }

    public void Upgrade()
    {
        _moneyCounter.TakeMoney(_tower.Cost);
        _tower.Upgrade();
        ChangeText();
        _spawnPlaceTowerBeaty.PlayParticles();

        if (_tower.TryGetComponent( out BarracksTower barracksTower))
            barracksTower.ChangeWarrior();
    }

    private void ChangeText()
    {
        _costText.text = _tower.Cost.ToString();
        _sellText.text = ((int)(_tower.Cost * _sellPercent)).ToString();

        if (_tower.IsMaxLevel == true)
        {
            _costText.text = "Max";
        }
        else
        {
            _costText.text = _tower.Cost.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Button _showButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private int _indexLevel;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;
    [SerializeField] private InfoTowerPanel _infoObject;

    private Tower _tower;
    private MoneyCounter _moneyCounter;

    private void Start()
    {
        _tower = _spawnPlaceTower.GetTower(_indexLevel);
        _priceText.text = _tower.BuyCost.ToString();
        _moneyCounter = FindObjectOfType<MoneyCounter>();

        if (_tower.TryGetComponent<BarracksTower>(out BarracksTower barracks))
        {
            _infoObject.SendData(_tower.Damage, _tower.Delay, barracks.WarriorHealth);
        }
        else
        {
            _infoObject.SendData(_tower.Damage, _tower.Delay);
        }
    }

    private void OnEnable()
    {
        ChangeButtons();
    }

    private void OnDisable()
    {
        ChangeButtons();
    }

    private void Update()
    {
        if (_tower.Cost >= _moneyCounter.Money)
            _showButton.interactable = false;
        else
            _showButton.interactable = true;
    }

    public void PlaceTower()
    {
        _moneyCounter.TakeMoney(_tower.BuyCost);
        _spawnPlaceTower.PlaceTower(_indexLevel);
    }

    public void ShowInfo()
    {
        _infoObject.gameObject.Activate();
        _spawnPlaceTower.ShowBlankTower(_indexLevel);
    }

    public void CloseInfo()
    {
        _infoObject.gameObject.Deactivate();
        _spawnPlaceTower.CloseBlankTower(_indexLevel);
    }

    public void ChangeButtons()
    {
        if (_buyButton != null)
        {
            _showButton.Activate();
            _buyButton.Deactivate();
        }
    }
}

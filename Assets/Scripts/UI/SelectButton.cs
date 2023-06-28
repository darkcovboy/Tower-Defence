using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _indexLevel;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;
    [SerializeField] private GameObject _infoObject;

    private Tower _tower;
    private MoneyCounter _moneyCounter;

    private void Start()
    {
        _tower = _spawnPlaceTower.GetTower(_indexLevel);
        _textMeshPro.text = _tower.BuyCost.ToString();
        _moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    private void Update()
    {
        if (_tower.Cost >= _moneyCounter.Money)
            _button.interactable = false;
        else
            _button.interactable = true;
    }

    public void PlaceTower()
    {
        _moneyCounter.TakeMoney(_tower.BuyCost);
        _spawnPlaceTower.PlaceTower(_indexLevel);
    }

    public void ShowInfo()
    {
        _infoObject.SetActive(true);
        _spawnPlaceTower.ShowBlankTower(_indexLevel);
    }

    public void CloseInfo()
    {
        _infoObject.SetActive(false);
        _spawnPlaceTower.CloseBlankTower(_indexLevel);
    }
}

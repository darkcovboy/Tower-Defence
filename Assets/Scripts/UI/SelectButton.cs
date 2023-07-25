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
    [SerializeField] private Image _lockImage;

    private Tower _tower;
    private MoneyCounter _moneyCounter;

    private void Start()
    {
        _tower = _spawnPlaceTower.GetTower(_indexLevel);
        _priceText.text = _tower.BuyCost.ToString();

        switch (_tower.TowerType)
        {
            case TowerType.IceMage:
                _lockImage.gameObject.SetActive(!MaxLevel.IsIceOpened);
                break;
            case TowerType.FireMage:
                _lockImage.gameObject.SetActive(!MaxLevel.IsFireOpened);
                break;
            case TowerType.LightningMage:
                _lockImage.gameObject.SetActive(!MaxLevel.IsLightningOpened);
                break;
            default:
                break;
        }
    }

    private void OnEnable()
    {
        ChangeButtons();
    }

    private void OnDisable()
    {
        _infoObject.Deactivate();
        ChangeButtons();
    }

    private void Update()
    {
        if (_tower.BuyCost > _moneyCounter.Money)
            _showButton.interactable = false;
        else
            _showButton.interactable = true;
    }

    public void Init(MoneyCounter moneyCounter) => _moneyCounter = moneyCounter;

    public void PlaceTower()
    {
        _moneyCounter.TakeMoney(_tower.BuyCost);
        CloseInfo();
        _spawnPlaceTower.PlaceTower(_indexLevel);
    }

    public void ShowInfo()
    {
        ChangeInfo();
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

    private void ChangeInfo()
    {
        if (_tower.TryGetComponent<BarracksTower>(out BarracksTower barracks))
        {
            _infoObject.SendData(_tower.Damage, _tower.Delay, barracks.WarriorHealth, barracks.Title, barracks.Description);
        }
        else
        {
            _infoObject.SendData(_tower.Damage, _tower.Delay, _tower.Title, _tower.Description);
        }
    }
}

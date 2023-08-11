using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

[RequireComponent(typeof(AudioSource))]
public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _showButton;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField, Range(0, 1)] private float _sellPercent;
    [SerializeField] private TextMeshProUGUI _sellText;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;
    [SerializeField] private SpawnPlaceTowerBeaty _spawnPlaceTowerBeaty;
    [SerializeField] private ChooseWarriorTarget _flagButton;
    [SerializeField] private InfoTowerPanel _shootingTowerInfo;
    [SerializeField] private InfoTowerPanel _barracksInfo;
    [SerializeField] private AudioDataProperty _audioDataProperty;

    private MoneyCounter _moneyCounter;
    private Tower _tower;
    private SourceAudio _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<SourceAudio>();
    }

    private void OnEnable()
    {
        _showButton.Activate();
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

    private void OnDisable()
    {
        CloseInfo();
    }

    private void Update()
    {
        if (_tower.Cost >= _moneyCounter.Money || _tower.IsMaxLevel == true)
            _upgradeButton.interactable = false;
        else
            _upgradeButton.interactable = true;
    }

    public void Init(MoneyCounter moneyCounter) => _moneyCounter = moneyCounter;

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

    public void ShowInfo()
    {
        _spawnPlaceTowerBeaty.ShowRange(_tower.Radius);

        if (_tower.TryGetComponent<BarracksTower>(out BarracksTower barracks))
        {
            _barracksInfo.SendData(_tower.Damage, _tower.Delay, barracks.WarriorHealth, barracks.Title, barracks.Description);
            _barracksInfo.Activate();
        }
        else
        {
            _shootingTowerInfo.SendData(_tower.Damage, _tower.Delay, _tower.Title, _tower.Description);
            _shootingTowerInfo.Activate();
        }
    }

    public void CloseInfo()
    {
        _spawnPlaceTowerBeaty.CloseRange();
        _barracksInfo.Deactivate();
        _shootingTowerInfo.Deactivate();
    }

    public void TowerChoice(ref Tower tower)
    {
        _tower = tower;
        ChangeText();
    }

    public void Sell()
    {
        _moneyCounter.AddMoney((int)(_sellPercent * _tower.Cost));
        _tower.ResetSettings();
        _tower.Deactivate();
        _spawnPlaceTowerBeaty.PlayParticles();
        _spawnPlaceTower.ResetSettings();
    }

    public void Upgrade()
    {
        _moneyCounter.TakeMoney(_tower.Cost);
        _tower.Upgrade();
        CloseInfo();
        ChangeText();
        _spawnPlaceTowerBeaty.PlayParticles();
        _audioSource.Play(_audioDataProperty.Key);

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

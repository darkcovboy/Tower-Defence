using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [Header("Level objects")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private SpawnPlaceTower[] _spawnPlaceTower;
    [SerializeField] private Camera _mainCamera;
    [Header("Spels")]
    [SerializeField] private SpellsCreator _spellsCreator;
    [Header("UI")]
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private MoneyBalance _moneyBalance;
    [SerializeField] private AdButton _adButton;
    [SerializeField] private SpellButton[] _spellButtons;
    [Header("GameManager")]
    [SerializeField] private ObjectManagerUI _objectManagerUI;
    [SerializeField] private SaveManager _saveManager;
    [SerializeField] private EndLevelManager _endLevelManager;
    [Header("Ads")]
    [SerializeField] private FullVideo _fullVideoAd;
    [SerializeField] private RewardedVideo _rewardedAd;

    private MeteorShoot _meteorShoot;
    private WarriorsCreator _warriorsCreator;

    private void Awake()
    {
        _objectManagerUI.Init(_mainCamera, _spawnPlaceTower);
        InitMoneyCounter();
        _moneyCounter.Init(_levelConfig.StartMoney);
        _rewardedAd.Init(_moneyCounter, _player, _levelConfig.AdStartMoney,_levelConfig.AdHealth);
        _adButton.Init(_levelConfig.AdStartMoney, _rewardedAd);
        _player.SetStartHealth(_levelConfig.StartHealth);
        _endLevelManager.Init(_spawner, _player, _levelConfig, _victoryScreen, _saveManager, _moneyCounter);
        MaxLevel.Set(_levelConfig.MaxLevel, _levelConfig.IsFireOpened, _levelConfig.IsIceOpened, _levelConfig.IsLightningOpened);
        InitSpels();
    }

    private void OnEnable()
    {
        _spawner.AllEnemysDied += EndLevel;
        _player.Dying += EndLevel;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= EndLevel;
        _player.Dying -= EndLevel;
    }

    private void EndLevel()
    {
        _objectManagerUI.CloseUI();
    }

    private void InitSpels()
    {
        _warriorsCreator = _spellsCreator.CreateWarrior(_levelConfig.IsOpenedWarriorCreator);
        _meteorShoot = _spellsCreator.CreateMeteor(_levelConfig.IsOpenedMeteor);

        foreach (var item in _spellButtons)
        {
            switch(item.Type)
            {
                case SpellType.Meteor:
                    if(_meteorShoot == null)
                        item.GetComponent<Button>().interactable = false;
                    else
                        _meteorShoot.Init(_objectManagerUI, _mainCamera, item);

                    break;
                case SpellType.WarriorCreator:
                    if (_warriorsCreator == null)
                        item.GetComponent<Button>().interactable = false;
                    else
                        _warriorsCreator.Init(_objectManagerUI, _mainCamera, item);
                    break;
            }
        }
    }

    private void InitMoneyCounter()
    {
        _spawner.Init(_moneyCounter);
        _moneyBalance.Init(_moneyCounter);

        foreach (var spawnPlaceTower in _spawnPlaceTower)
        {
            spawnPlaceTower.Init(_objectManagerUI);
            var selectButtons = spawnPlaceTower.gameObject.GetComponentsInChildren<SelectButton>(true);
            var upgradePanel = spawnPlaceTower.gameObject.GetComponentInChildren<UpgradePanel>(true);
            upgradePanel.Init(_moneyCounter);

            foreach (var selectButton in selectButtons)
            {
                selectButton.Init(_moneyCounter);
            }
        }
    }
}

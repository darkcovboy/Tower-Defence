using UnityEngine;
using Zenject;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private LevelPrefabsContainer _container;
    [SerializeField] private LevelTemporaryPrefabs _containerTemproraryPrefabs;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Camera _mainCamera;
    [Header("Positions")]
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _spawnerPosition;
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private Transform[] _placeTowerPositions;
    [Header("Canvas Objects")]
    [SerializeField] private TimeToSpawnNextWaveScreen _timeToSpawnNextWaveScreen;
    [SerializeField] private VictoryScreen _victoryScreen;


    private BackgroundChangeEvent _backgroundChangeEvent;

    public override void InstallBindings()
    {
        CreateSceneFader();
        CreateMoneyCounter();
        CreatePlayer();
        CreateSpawner();
        CreateSpawnPlaceTower();
        CreateAds();
        CreateBackgroundChangeEvent();
        CreateSoundButton();
        BindCanvasObjects();
    }

    private void CreateBackgroundChangeEvent()
    {
        _backgroundChangeEvent = new BackgroundChangeEvent();
    }

    private void BindCanvasObjects()
    {
        Container.Bind<TimeToSpawnNextWaveScreen>().FromInstance(_timeToSpawnNextWaveScreen).AsSingle();
        Container.Bind<VictoryScreen>().FromInstance(_victoryScreen).AsSingle();
    }

    private void CreateMoneyCounter()
    {
        MoneyCounter moneyCounter = new MoneyCounter(_levelConfig.StartMoney);
        Container.Bind<MoneyCounter>().FromInstance(moneyCounter).AsSingle();
        Container.Bind<IMoneyHandler>().To<MoneyCounter>().FromInstance(moneyCounter).AsSingle();
    }

    private void CreateSceneFader()
    {
        SceneFader sceneFader = Container.InstantiatePrefabForComponent<SceneFader>(_container.FaderPrefab);
        Container.Bind<SceneFader>().FromInstance(sceneFader).AsSingle();
    }

    private void CreateSpawner()
    {
        Spawner spawner = Container.InstantiatePrefabForComponent<Spawner>(_containerTemproraryPrefabs.Spawner, _spawnerPosition);
        Container.Bind<Spawner>().FromInstance(spawner).AsSingle();
        Container.Bind<IDiedHandler>().To<Spawner>().FromInstance(spawner).AsSingle();
        Container.Bind<ISpawnedHandler>().To<Spawner>().FromInstance(spawner).AsSingle();
        Container.Bind<Waypoints>().FromInstance(_waypoints).AsSingle();
    }

    private void CreateSoundButton()
    {
        SoundButton soundButton = Container.InstantiatePrefabForComponent<SoundButton>(_container.SoundButton);
        Container.Bind<SoundButton>().FromInstance(soundButton).AsSingle();
    }

    private void CreateSpawnPlaceTower()
    {
        SpawnPlaceTower[] places = new SpawnPlaceTower[_placeTowerPositions.Length];

        for (int i = 0; i < _placeTowerPositions.Length; i++)
        {
            SpawnPlaceTower spawnPlaceTower = Container.InstantiatePrefabForComponent<SpawnPlaceTower>(_container.SpawnPlaceTowerPrefab, _placeTowerPositions[i]);
            places[i] = spawnPlaceTower;
        }

        Container.Bind<SpawnPlaceTower[]>().FromInstance(places).AsSingle();
    }

    private void CreatePlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_containerTemproraryPrefabs.Player, _playerPosition);
        player.SetStartHealth(_levelConfig.StartHealth);
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<IHealible>().To<Player>().FromInstance(player).AsSingle();
        Container.Bind<IHealthHandler>().To<Player>().FromInstance(player).AsSingle();
    }

    private void CreateAds()
    {
        RewardedHealthVideo rewardedHealthVideo = new RewardedHealthVideo(_playerPosition, _levelConfig.AdHealth);
        RewardedMoneyVideo rewardedMoneyVideo = new RewardedMoneyVideo(_levelConfig.AdStartMoney);
        FullVideo fullVideo = new FullVideo(LoadingPanel.Instance);
        Container.Bind<FullVideo>().FromInstance(fullVideo).AsSingle();
        Container.Bind<RewardedMoneyVideo>().FromInstance(rewardedMoneyVideo).AsSingle();
        Container.Bind<RewardedHealthVideo>().FromInstance(rewardedHealthVideo).AsSingle();
    }
}

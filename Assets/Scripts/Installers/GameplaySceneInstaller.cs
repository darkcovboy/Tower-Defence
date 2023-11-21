using UnityEngine;
using Zenject;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private LevelPrefabsContainer _container;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private Camera _mainCamera;
    [Header("Positions")]
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _spawnerPosition;
    [SerializeField] private Transform[] _enemyPoint;
    [SerializeField] private Transform[] _placeTowerPositions;

    public override void InstallBindings()
    {
        CreateSceneFader();
        CreateMoneyCounter();
        CreatePlayer();
        CreateSpawner();
        CreateSpawnPlaceTower();
        CreateAds();
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
        Spawner spawner = Container.InstantiatePrefabForComponent<Spawner>(_container.SpawnerPrefab);
        Container.Bind<Spawner>().FromInstance(spawner).AsSingle();
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
        Player player = Container.InstantiatePrefabForComponent<Player>(_container.Player, _playerPosition);
        player.SetStartHealth(_levelConfig.StartHealth);
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<IHealible>().To<Player>().FromInstance(player).AsSingle();
        Container.Bind<IHealthHandler>().To<Player>().FromInstance(player).AsSingle();
    }

    private void CreateAds()
    {
        RewardedHealthVideo rewardedHealthVideo = new RewardedHealthVideo(_playerPosition, _levelConfig.AdHealth);
        RewardedMoneyVideo rewardedMoneyVideo = new RewardedMoneyVideo(_levelConfig.AdStartMoney);
        Container.Bind<RewardedMoneyVideo>().FromInstance(rewardedMoneyVideo).AsSingle();
        Container.Bind<RewardedHealthVideo>().FromInstance(rewardedHealthVideo).AsSingle();
    }
}

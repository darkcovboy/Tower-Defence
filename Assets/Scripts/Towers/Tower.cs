using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int Level;
    [SerializeField] protected TowerData TowerDataConfig;
    [SerializeField] protected List<GameObject> LevelsTower;
    [SerializeField] protected List<Transform> StartPositions;
    [SerializeField] protected Transform LookAtTarget;

    public int Cost => TowerDataConfig.Costs[Level];
    public int LevelCurrent => Level;
    public bool IsMaxLevel => Level == _maxLevel;

    public int Damage => TowerDataConfig.Damages[Level];
    public float Delay => TowerDataConfig.Delays[Level];

    public int BuyCost => TowerDataConfig.BuyCost;

    public TowerType TowerType => TowerDataConfig.TowerType;

    public float Radius => TowerDataConfig.Radiuses[Level];

    public LeanPhrase Title => TowerDataConfig.Title;
    public LeanPhrase Description => TowerDataConfig.Description;
    public int CurrentLevel => Level;

    private int _maxLevel;

    private void Awake()
    {
        Level = 0;
        ChooseTower();

        switch(TowerDataConfig.TowerType)
        {
            case (TowerType.Archer):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelArcher;
                break;
            }
            case (TowerType.Barracks):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelBarracks;
                break;
            }
            case (TowerType.Canon):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelCanon;
                break;
            }
            case (TowerType.FireMage):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelFireMage;
                break;
            }
            case (TowerType.IceMage):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelIceMage;
                break;
            }
            case (TowerType.LightningMage):
            {
                _maxLevel = TowerUnlockSettings.MaxLevelLightningMage;
                break;
            }
        }


        if (gameObject.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider))
        {
            capsuleCollider.radius = TowerDataConfig.Radiuses[Level];
        }

        transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);
    }

    public void Upgrade()
    {
        Debug.Log((Level + 1) + " " + _maxLevel);

        if (Level + 1 > _maxLevel)
        {
            Level = _maxLevel;  
        }
        else
        {
            Level++;
        }

        ChooseTower();
    }

    public void ResetSettings()
    {
        Level = 0;
        ChooseTower();
    }

    private void ChooseTower()
    {
        foreach (var _object in LevelsTower)
        {
            _object.SetActive(false);
        }

        LevelsTower[Level].SetActive(true);
    }
}

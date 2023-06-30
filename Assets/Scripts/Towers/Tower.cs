using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int Level;
    [SerializeField] protected TowerData TowerDataConfig;
    [SerializeField] protected List<GameObject> LevelsTower;
    [SerializeField] protected List<Transform> StartPositions;
    [SerializeField] protected Transform LookAtTarget;

    public int Cost => TowerDataConfig.Costs[Level];
    public bool IsMaxLevel => Level == _maxLevel;

    public int BuyCost => TowerDataConfig.BuyCost;

    public TowerType TowerType => TowerDataConfig.TowerType;

    private readonly int _maxLevel = 3;

    private void Start()
    {
        Level = 0;
        ChooseTower();
        transform.LookAt(LookAtTarget);
        transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);
    }

    public void Upgrade()
    {
        if(Level + 1 > _maxLevel)
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

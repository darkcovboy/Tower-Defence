using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    Archer,
    Canon,
    IceMage,
    FireMage,
    Barracks
}

public class Tower : MonoBehaviour
{
    [SerializeField] protected List<GameObject> LevelsTower;
    [SerializeField] protected List<Transform> StartPositions;
    [SerializeField] protected Transform LookAtTarget;
    [SerializeField] private TowerType _towerType;

    [SerializeField] protected int Level;
    [SerializeField] protected List<int> Costs;
    [SerializeField] protected List<float> Delay;
    [SerializeField] protected List<int> Damages;
    [SerializeField] protected int Radius;
    [SerializeField] private int _buyCost;

    public int Cost => Costs[Level];
    public bool IsMaxLevel => Level == _maxLevel;

    public int BuyCost => _buyCost;

    public TowerType TowerType => _towerType;

    private readonly int _maxLevel = 3;

    private void Start()
    {
        Debug.Log(Costs[0].ToString());
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

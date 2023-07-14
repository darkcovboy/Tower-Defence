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
    public bool IsMaxLevel => Level == _maxLevel;

    public int Damage => TowerDataConfig.Damages[Level];
    public float Delay => TowerDataConfig.Delays[Level];

    public int BuyCost => TowerDataConfig.BuyCost;

    public TowerType TowerType => TowerDataConfig.TowerType;

    public float Radius => TowerDataConfig.Radius;

    public LeanPhrase Title => TowerDataConfig.Title;
    public LeanPhrase Description => TowerDataConfig.Description;

    private readonly int _maxLevel = 3;

    private void Start()
    {
        Level = 0;
        ChooseTower();
        if(LookAtTarget != null)
            transform.LookAt(LookAtTarget.position);

        if (gameObject.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider))
        {
            capsuleCollider.radius = TowerDataConfig.Radius;
        }

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

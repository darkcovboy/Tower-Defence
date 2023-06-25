using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected int Level;
    [SerializeField] protected List<int> Costs;
    [SerializeField] protected List<float> Delay;
    [SerializeField] protected List<int> Damages;
    [SerializeField] protected List<int> Radiuses;
    [SerializeField] protected List<GameObject> LevelsTower;
    [SerializeField] protected List<Transform> StartPositions;
    [SerializeField] protected Transform LookAtTarget;

    public int Cost => Costs[Level];
    public int Radius => Radiuses[Level];
    public bool IsMaxLevel => Level == _maxLevel;

    private readonly int _maxLevel = 3;

    private void Start()
    {
        Level = 0;
        ChooseTower();
        transform.LookAt(LookAtTarget);
        transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);
        gameObject.GetComponent<CapsuleCollider>().radius = Radiuses[Level];
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

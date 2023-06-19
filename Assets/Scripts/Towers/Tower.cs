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
    [SerializeField] protected List<GameObject> LevelsTower;
    [SerializeField] protected List<Transform> StartPositions;

    public int Cost => Costs[Level];

    public void Upgrade()
    {
        Level++;

        foreach(var _object in LevelsTower)
        {
            _object.SetActive(false);
        }

        LevelsTower[Level].SetActive(true);
    }
}

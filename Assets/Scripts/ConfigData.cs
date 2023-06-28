using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigData : ScriptableObject
{
    [Header("ArcherTower")]
    public List<int> ArcherCost;
    public List<float> ArcherDelays;
    public List<int> ArcherDamages;
    [Range(0, 25)]
    public int ArcherRadius;

    [Header("BarracksTower")]
    public List<int> BarracksCost;
    public List<float> BarracksDelays;
    public List<int> BarracksDamages;
    [Range(0,25)]
    public int BarracksRadius;
    public List<GameObject> WarriorsPrefabs;

    [Header("CanonTower")]
    public List <int> CanonTowerCost;
    public List<float> CanonTowerDelays;
    public List<int> CanonTowerDamages;
    [Range(0,25)]
    public int CanonTowerRadius;

    [Header("FireMageTower")]
    public List<int> FireMageCost;
    public List<float> FireMageDelays;
    public List<int> FireMageDamages;
    [Range(0, 25)]
    public int FireMageRadius;

    [Header("IceMageTower")]
    public List<int> IceMageCost;
    public List<float> IceMageDelays;
    public List<int> IceMageDamages;
    [Range(0, 25)]
    public int IceMageRadius;
}

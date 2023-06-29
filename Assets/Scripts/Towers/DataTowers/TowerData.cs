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
[CreateAssetMenu(fileName = "New Tower", menuName = "Tower Data")]
public class TowerData : ScriptableObject
{
    public List<int> Costs;
    public int BuyCost;
    public List<int> Damages;
    public List<float> Delays;
    public TowerType TowerType;
    [Range(10, 30)] public int Radius;
}

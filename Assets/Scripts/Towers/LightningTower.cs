using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTower : ShootingTower
{
    [SerializeField] private LightningEffect _lightningEffect;

    protected override void Shoot()
    {
        MissleSpawners.PushMissle(Target, Enemy, TowerDataConfig.Damages[Level], StartPositions[Level], Level, _lightningEffect);
    }
}

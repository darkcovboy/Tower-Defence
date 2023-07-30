using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPanelLightning : TowerPanel
{
    [SerializeField] private LightningData _lightningData;
    [SerializeField] private TextMeshProUGUI[] _maxLightningEnemy;

    protected override void EnterValues()
    {
        base.EnterValues();

        for (int i = 0; i < MaxItems; i++)
        {
            _maxLightningEnemy[i].text = _lightningData.MaxEnemies[i].ToString();
        }
    }
}

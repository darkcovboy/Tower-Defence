using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPanelFire : TowerPanel
{
    [SerializeField] private FireEffectData _fireEffectData;
    [SerializeField] private TextMeshProUGUI[] _burnDamages;

    protected override void EnterValues()
    {
        base.EnterValues();

        for (int i = 0; i < MaxItems; i++)
        {
            _burnDamages[i].text = _fireEffectData.BurnDamage[i].ToString();
        }
    }
}

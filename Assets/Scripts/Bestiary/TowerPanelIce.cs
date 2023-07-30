using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPanelIce : TowerPanel
{
    [SerializeField] private IceEffectData _iceEffectData;
    [SerializeField] private TextMeshProUGUI[] _iceSlowDown;

    protected override void EnterValues()
    {
        base.EnterValues();

        for (int i = 0; i < MaxItems; i++)
        {
            _iceSlowDown[i].text = _iceEffectData.IceSlowDownPercentage[i].ToString();
        }
    }
}

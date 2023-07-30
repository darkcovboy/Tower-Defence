using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPanelBarracks : TowerPanel
{
    [SerializeField] private WarriorData _warrior;
    [SerializeField] private TextMeshProUGUI[] _healthWarriors;

    protected override void EnterValues()
    {
        base.EnterValues();

        for (int i = 0; i < MaxItems; i++)
        {
            _healthWarriors[i].text = _warrior.HealthWarriors[i].ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTowerButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private TowerPanelManager _panelManager;
    [SerializeField] private int _selectedTowerIndex;
     
    protected override void OnButtonClick()
    {
        _panelManager.OpenPanel(_selectedTowerIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanelManager : MonoBehaviour
{
    [SerializeField] private TowerPanel[] _towerPanels;

    public void OpenPanel(int index)
    {
        foreach (var panel in _towerPanels)
        {
            panel.Deactivate();
        }

        _towerPanels[index].Activate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
using TMPro;

public class TowerPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelPanels;
    [SerializeField] private TowerData _data;
    [SerializeField] private Image[] _icons;
    [SerializeField] private TextMeshProUGUI[] _fireRate;
    [SerializeField] private TextMeshProUGUI[] _damages;

    private readonly int _maxItems; 

    private void Awake()
    {
        for (int i = 0; i < _maxItems; i++)
        {
            _fireRate[i].text = _data.Delays[i].ToString();
            _damages[i].text = _data.Damages[i].ToString();
            _levelPanels[i].Deactivate();
        }
    }

    public void SwapPanel(int index)
    {
        foreach (var levelPanel in _levelPanels)
        {
            levelPanel.Deactivate();
        }

        _levelPanels[index].Activate();
    }
}

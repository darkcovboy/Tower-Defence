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
    [SerializeField] private TextMeshProUGUI[] _fireRate;
    [SerializeField] private TextMeshProUGUI[] _damages;

    protected readonly int MaxItems = 4;
    private readonly int _firstIndex = 0;

    private void Awake()
    {
        EnterValues();
    }

    public void SwapPanel(int index)
    {
        foreach (var levelPanel in _levelPanels)
        {
            levelPanel.Deactivate();
        }

        _levelPanels[index].Activate();
    }

    protected virtual void EnterValues()
    {
        for (int i = 0; i < MaxItems; i++)
        {
            _fireRate[i].text = _data.Delays[i].ToString();
            _damages[i].text = _data.Damages[i].ToString();
            _levelPanels[i].Deactivate();
        }

        _levelPanels[_firstIndex].Activate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject _firstPanelUI;
    [SerializeField] private UpgradePanel _upgradePanelUI;
    [SerializeField] private GameObject _magePanelUI;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject[] _blankTowers;

    private GameObject _currentPanel;

    private void Start()
    {
        _currentPanel = _firstPanelUI;
    }

    public void PlaceTower(int index)
    {
        _towers[index].gameObject.SetActive(true);
        _currentPanel.SetActive(false);
        _upgradePanelUI.TowerChoice(ref _towers[index]);
        _currentPanel = _upgradePanelUI.gameObject;
    }

    public void ShowBlankTower(int index)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        _blankTowers[index].SetActive(true);
    }

    public void CloseBlankTower(int index)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        _blankTowers[index].SetActive(false);
    }

    public void OpenPanel()
    {
        _currentPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        _currentPanel.SetActive(false);
    }

    public Tower GetTower(int index)
    {
        return _towers[index];
    }

    public void ResetSettings()
    {
        _currentPanel.SetActive(false);
        _currentPanel = _firstPanelUI;
    }
}

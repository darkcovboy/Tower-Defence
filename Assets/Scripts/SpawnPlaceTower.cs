using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject _firstPanelUI;
    [SerializeField] private GameObject _upgradePanelUI;
    [SerializeField] private GameObject _magePanelUI;
    [SerializeField] private Tower[] _towers;
    [SerializeField] private Transform _target;

    private GameObject _currentPanel;

    private void Start()
    {
        _currentPanel = _firstPanelUI;
    }

    public void PlaceTower(int index)
    {
        Instantiate(_towers[index].gameObject, transform);
        _currentPanel.SetActive(false);
        _currentPanel = _upgradePanelUI;
    }

    public void OpenPanel()
    {
        if (_currentPanel.gameObject.activeSelf == true)
            _currentPanel.SetActive(false);
        else
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
}

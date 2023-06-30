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

    private GameObject _currentPanel;
    private ObjectManagerUI _objectManager;
    private SpawnPlaceTowerBeaty _spawnPlaceTowerBeaty;

    private void Start()
    {
        _objectManager = FindObjectOfType<ObjectManagerUI>();
        _currentPanel = _firstPanelUI;
        _spawnPlaceTowerBeaty = GetComponent<SpawnPlaceTowerBeaty>();

    }

    public void PlaceTower(int index)
    {
        _spawnPlaceTowerBeaty.CloseBlankTower();
        _spawnPlaceTowerBeaty.PlayParticles();
        _towers[index].gameObject.Activate();
        _currentPanel.Deactivate();
        _upgradePanelUI.TowerChoice(ref _towers[index]);
        _currentPanel = _upgradePanelUI.gameObject;
    }

    public void ShowBlankTower(int index)
    {
        _spawnPlaceTowerBeaty.ShowBlankTower(index);
    }

    public void CloseBlankTower(int index)
    {
        _spawnPlaceTowerBeaty.CloseBlankTower(index);
    }

    public void OpenPanel()
    {
        _objectManager.CloseUI();
        _currentPanel.Activate();
    }

    public void ClosePanel()
    {
        _spawnPlaceTowerBeaty.CloseBlankTower();
        _upgradePanelUI.CloseRangeField();
        _currentPanel.Deactivate();
        
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

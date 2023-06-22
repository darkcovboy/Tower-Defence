using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _indexLevel;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private SpawnPlaceTower _spawnPlaceTower;

    private Tower _tower;

    private void Awake()
    {
        _tower = _spawnPlaceTower.GetTower(_indexLevel);
    }

    private void Start()
    {
        _textMeshPro.text = _tower.Cost.ToString();
    }

    public void Upgrade()
    {
        _button.Select();
    }
}

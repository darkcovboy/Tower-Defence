using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceTowerBeaty : MonoBehaviour
{
    [SerializeField] private GameObject _range;
    [SerializeField] private GameObject[] _blankTowers;
    [SerializeField] private ParticleSystem _buildingParticles;

    public void ShowBlankTower(int index)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        _blankTowers[index].Activate();
        _range.Activate();
    }

    public void CloseBlankTower(int index)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        _blankTowers[index].Deactivate();
        _range.Deactivate();
    }

    public void CloseBlankTower()
    {
        foreach (var blank in _blankTowers)
        {
            blank.Deactivate();
        }

        _range.Deactivate();
    }

    public void PlayParticles()
    {
        _buildingParticles.Play();
    }
}

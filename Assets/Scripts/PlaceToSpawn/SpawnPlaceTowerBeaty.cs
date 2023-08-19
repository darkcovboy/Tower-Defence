using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class SpawnPlaceTowerBeaty : MonoBehaviour
{
    [SerializeField] private GameObject _range;
    [SerializeField] private GameObject[] _blankTowers;
    [SerializeField] private ParticleSystem _buildingParticles;
    [SerializeField] private AudioDataProperty _audioKey;

    private SourceAudio _buildingSound;
    private void Start()
    {
        _buildingSound = GetComponent<SourceAudio>();
    }

    public void ShowBlankTower(int index, float radius)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        ShowRange(radius);
        _blankTowers[index].Activate();
    }

    public void CloseBlankTower(int index)
    {
        if (index >= _blankTowers.Length)
        {
            index = _blankTowers.Length;
            index--;
        }

        _blankTowers[index].Deactivate();
        CloseRange();
    }

    public void CloseBlankTower()
    {
        foreach (var blank in _blankTowers)
        {
            blank.Deactivate();
        }

        CloseRange();
    }

    public void ShowRange(float radius)
    {
        float diametr = radius * 2f;
        _range.transform.localScale = new Vector3(diametr, _range.transform.localScale.y, diametr);
        _range.Activate();
    }

    public void CloseRange() => _range.Deactivate();

    public void PlayParticles() => _buildingParticles.Play();

    public void PlaySound() => _buildingSound.Play(_audioKey.Key);
}

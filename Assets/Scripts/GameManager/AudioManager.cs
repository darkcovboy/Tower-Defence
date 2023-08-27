using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Button _audioOff;
    [SerializeField] private Button _audioOn;
    [SerializeField] private Slider _sliderVolume;

    public float CurrentVolume => _currentVolume;

    private float _currentVolume;
    private float _lastCurrentVolume;

    private void Start()
    {
        _audioOff.onClick.AddListener(MuteAudio);
        _audioOn.onClick.AddListener(PlayAudio);
        _sliderVolume.onValueChanged.AddListener(OnSliderChanged);
        _currentVolume = _sliderVolume.value;
    }

    public void OnSliderChanged(float volume)
    {
        AudioListener.volume = volume;

        if (volume > 0)
        {
            _currentVolume = volume;
            PlayAudio();
        }
        else
        {
            MuteAudio();
        }
        
    }

    public void AudioChange(bool flag)
    {
        if (flag)
            PlayAudio();
        else
            MuteAudio();
    }

    private void MuteAudio()
    {
        _audioOff.Deactivate();
        _audioOn.Activate();
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    private void PlayAudio()
    {
        _audioOff.Activate();
        _audioOn.Deactivate();
        AudioListener.pause = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Button _audioOff;
    [SerializeField] private Button _audioOn;
    [SerializeField] private Slider _sliderVolume;

    private void Start()
    {
        _audioOff.onClick.AddListener(MuteAudio);
        _audioOn.onClick.AddListener(PlayAudio);
        _sliderVolume.onValueChanged.AddListener(OnSliderChanged);
    }

    public void OnSliderChanged(float volume)
    {
        AudioListener.volume = volume;
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
    }

    private void PlayAudio()
    {
        _audioOff.Activate();
        _audioOn.Deactivate();
        AudioListener.pause = false;
    }
}

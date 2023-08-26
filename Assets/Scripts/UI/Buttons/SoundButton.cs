using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource _button;
    [SerializeField] private AudioSource _nextWaveButton;

    public void Play()
    {
        _button.Play();
    }

    public void PlayNextWave()
    {
        _nextWaveButton.Play();
    }
}

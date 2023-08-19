using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvent : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        // Use both pause and volume muting methods at the same time.
        // They're both broken in Web, but work perfect together. Trust me on this.
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
        Time.timeScale = inBackground ? 0f : _audioManager.CurrentVolume;
    }
}

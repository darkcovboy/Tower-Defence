using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine.UI;
[RequireComponent(typeof(SourceAudio))]

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioDataProperty _buttonData;
    [SerializeField] private AudioDataProperty _nextWaveData;

    private SourceAudio _sourceAudio;

    private void Start()
    {
        _sourceAudio = gameObject.GetComponent<SourceAudio>();
    }

    public void Play()
    {
        _sourceAudio.Play(_buttonData.Key);
    }

    public void PlayNextWave()
    {
        _sourceAudio.Play(_nextWaveData.Key);
    }
}

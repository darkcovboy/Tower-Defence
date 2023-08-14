using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine.UI;
[RequireComponent(typeof(SourceAudio))]

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioDataProperty _audioData;

    private SourceAudio _sourceAudio;

    private void Start()
    {
        _sourceAudio = gameObject.GetComponent<SourceAudio>();
    }

    public void Play()
    {
        _sourceAudio.Play(_audioData.Key);
    }
}

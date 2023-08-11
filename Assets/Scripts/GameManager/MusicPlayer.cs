using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private SourceAudio _sourceAudio;
    [SerializeField] private AudioDataProperty dataProperty;

    private void Start()
    {
        _sourceAudio.Play(dataProperty.Key);
    }
}

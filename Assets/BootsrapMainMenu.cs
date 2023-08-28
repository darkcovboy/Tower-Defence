using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsrapMainMenu : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private BackgroundChangeEvent backgroundChangeEvent;

    private void Awake()
    {
        backgroundChangeEvent.Init(audioManager);
    }
}

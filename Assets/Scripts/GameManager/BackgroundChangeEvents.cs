using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChangeEvents : MonoBehaviour
{
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnBackgroundChanged;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnBackgroundChanged;
    }

    private void OnBackgroundChanged(bool isNotGameView)
    {
        if(isNotGameView)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}

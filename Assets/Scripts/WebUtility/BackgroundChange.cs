using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;

public class BackgroundChange : MonoBehaviour
{
    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnBackGroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnBackGroundChange;
    }

    private void OnBackGroundChange(bool isChanged)
    {
        if (isChanged)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
    }
}

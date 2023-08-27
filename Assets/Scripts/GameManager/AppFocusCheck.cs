using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFocusCheck : MonoBehaviour
{
    private float _timeScace;

    private void OnApplicationFocus(bool focus)
    {
        AppFocus(!focus);
    }

    private void OnApplicationPause(bool pause)
    {
        AppFocus(pause);
    }

    private void AppFocus(bool checkFocus)
    {
        AudioListener.pause = checkFocus;
        AudioListener.volume = checkFocus ? 0 : 1;

        if (checkFocus)
        {
            _timeScace = Time.timeScale;
            Time.timeScale = 0;        
        }

        if (!checkFocus)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = _timeScace;
            }
        }
    }
}

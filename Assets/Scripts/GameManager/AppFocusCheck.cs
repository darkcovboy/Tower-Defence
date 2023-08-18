using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFocusCheck : MonoBehaviour
{
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
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}

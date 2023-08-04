using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceDefinder
{
    public static bool isDesktop;

    public static void Define()
    {
        if (Application.isMobilePlatform)
        {
            isDesktop = false;
        }
        else
        {
            isDesktop = true;
        }
    }
}

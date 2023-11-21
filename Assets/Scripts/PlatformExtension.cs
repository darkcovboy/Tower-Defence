using UnityEngine;
using UnityEngine.InputSystem;

public static class PlatformExtension
{
    public static void PlatformClicked(this Vector2 vector2)
    {
        if (DeviceDefinder.isDesktop)
        {
            vector2 = Mouse.current.position.ReadValue();
        }
        else
        {
            vector2 = Touchscreen.current.primaryTouch.position.ReadValue();
        }
    }
}

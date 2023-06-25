using UnityEngine;
using System;

public static class ComponentExtension
{
    public static void Activate(this Component component) => component.gameObject.SetActive(true);
    public static void Deactivate(this Component component) => component.gameObject.SetActive(false);
}

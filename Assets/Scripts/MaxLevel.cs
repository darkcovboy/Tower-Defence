using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLevel
{
    public static int MaxLevelTower => _maxLevel;
    public static bool IsFireOpened => _isFireOpened;
    public static bool IsIceOpened => _isIceOpened;
    public static bool IsLightningOpened => _isLightningOpened;

    private static int _maxLevel;
    private static bool _isFireOpened;
    private static bool _isIceOpened;
    private static bool _isLightningOpened;

    public static void Set(int level, bool fireFlag, bool iceFlag, bool lightningFlag)
    {
        _maxLevel = level;
        _isFireOpened = fireFlag;
        _isIceOpened = iceFlag;
        _isLightningOpened = lightningFlag;
    }
}

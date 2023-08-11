using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUnlockSettings
{
    public static int MaxLevelArcher => _maxLevelArcher;
    public static int MaxLevelBarracks => _maxLevelBarracks;
    public static int MaxLevelCanon => _maxLevelCanon;
    public static int MaxLevelFireMage => _maxLevelFireMage;
    public static int MaxLevelIceMage => _maxLevelIceMage;
    public static int MaxLevelLightningMage => _maxLevelLightningMage;

    public static bool IsFireOpened => _isFireOpened;
    public static bool IsIceOpened => _isIceOpened;
    public static bool IsLightningOpened => _isLightningOpened;

    private static int _maxLevelArcher;
    private static int _maxLevelBarracks;
    private static int _maxLevelCanon;
    private static int _maxLevelFireMage;
    private static int _maxLevelIceMage;
    private static int _maxLevelLightningMage;
    private static bool _isFireOpened;
    private static bool _isIceOpened;
    private static bool _isLightningOpened;

    public static void Set(int archerLevel, int barracksLevel, int canonLevel, int fireMageLevel, int iceMageLevel, int lightningMageLevel, bool fireFlag, bool iceFlag, bool lightningFlag)
    {
        _maxLevelArcher = archerLevel;
        _maxLevelBarracks = barracksLevel;
        _maxLevelCanon = canonLevel;
        _maxLevelFireMage = fireMageLevel;
        _maxLevelIceMage = iceMageLevel;
        _maxLevelLightningMage = lightningMageLevel;
        _isFireOpened = fireFlag;
        _isIceOpened = iceFlag;
        _isLightningOpened = lightningFlag;
    }
}

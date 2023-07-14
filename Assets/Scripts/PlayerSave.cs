using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Newtonsoft.Json;

public class PlayerSave
{
    private int _maxLevel;
    private readonly float volumeStart = 0.5f;
    private readonly int firstLevelId = 1;

    public PlayerSave(int maxLevel)
    {
        _maxLevel = maxLevel;
    }

    public SaveDataWrapper LoadData(string data)
    {
        string json = data;
        SaveDataWrapper dataWrapper = JsonUtility.FromJson<SaveDataWrapper>(json);
        return dataWrapper;
    }

    public SaveDataWrapper LoadData()
    {
        SaveDataWrapper saveDataWrapper = new SaveDataWrapper();
        saveDataWrapper.levelDataList = InitLevelData();
        saveDataWrapper.settingsData = InitVolumeData();
        return saveDataWrapper;
    }

    private List<LevelData> InitLevelData()
    {
        List<LevelData> levelDataList = new List<LevelData>();

        for (int i = 1; i <= _maxLevel; i++)
        {
            LevelData levelData = new LevelData();
            levelData.LevelId = i;
            levelData.Stars = 0;
            levelData.Score = 0;

            if (levelData.LevelId == firstLevelId)
            {
                levelData.IsUnblock = true;
            }

            levelDataList.Add(levelData);
        }

        return levelDataList;
    }
    private VolumeData InitVolumeData()
    {
        VolumeData volumeData = new VolumeData();
        volumeData.Volume = volumeStart;
        return volumeData;
    }
}

public class LevelData
{
    public int LevelId;
    public bool IsUnblock = false;
    public int Stars;
    public int Score;
}

public class VolumeData
{
    public float Volume;
    public bool SoundEnabled = true;
}

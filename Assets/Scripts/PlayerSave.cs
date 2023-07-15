using System.Collections;
using System.Collections.Generic;
using System;
using Agava.YandexGames;
using Newtonsoft.Json;
using UnityEngine;

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
        SaveDataWrapper saveDataWrapper = new()
        {
            levelDataList = InitLevelData(),
            settingsData = InitVolumeData()
        };
        return saveDataWrapper;
    }

    public SaveDataWrapper LoadRandomData()
    {
        SaveDataWrapper saveDataWrapper = new()
        {
            levelDataList = InitRandomLevelData(),
            settingsData = InitRandomVolumeData()
        };
        return saveDataWrapper;
    }

    private List<LevelData> InitLevelData()
    {
        List<LevelData> levelDataList = new();

        for (int i = 1; i <= _maxLevel; i++)
        {
            LevelData levelData = new()
            {
                LevelId = i,
                Stars = 0,
                Score = 0
            };

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
        VolumeData volumeData = new()
        {
            Volume = volumeStart
        };
        return volumeData;
    }

    private VolumeData InitRandomVolumeData()
    {
        VolumeData volumeData = new()
        {
            Volume = 0.5f
        };
        return volumeData;
    }

    private List<LevelData> InitRandomLevelData()
    {
        List<LevelData> levelDataList = new();

        System.Random random = new System.Random();

        for (int i = 1; i <= _maxLevel; i++)
        {
            LevelData levelData = new()
            {
                LevelId = i,
                Stars = random.Next(0, 3),
                Score = random.Next(100, 1000)
            };

            if (levelData.LevelId == firstLevelId)
            {
                levelData.IsUnblock = true;
            }

            levelDataList.Add(levelData);
        }

        return levelDataList;
    }
}

[System.Serializable]
public class LevelData
{
    public int LevelId;
    public bool IsUnblock = false;
    public int Stars;
    public int Score;
}

[System.Serializable]
public class VolumeData
{
    public float Volume;
    public bool SoundEnabled = true;
}

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
    private readonly int _scoreStart;
   /*
    * Статический класс для работы с данными, в теории посмотрю что сюда ещё можно перетаскать, его присутствие на сцене не нужно, поэтому он и статический
    * У нас два класса здесь создаются LevelData - для работы с уровнями и VolumeData - для сохранения настроек звука, LoadData нам возвращает стандартный значения для этих классов, ну Init понятно что делают + Важное уточнение - классы нужно было сделать сериализируемыми, иначе они бы не работали с JSON форматом
   */

    public PlayerSave(int maxLevel)
    {
        _maxLevel = maxLevel;
    }

    public SaveDataWrapper LoadData()
    {
        SaveDataWrapper saveDataWrapper = new()
        {
            LevelDataList = InitLevelData(),
            SettingsData = InitVolumeData(),
            Score = _scoreStart
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
                Stars = 0
            };

            if (levelData.LevelId == firstLevelId)
            {
                levelData.IsUnblock = true;
            }
            else
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
}

[System.Serializable]
public class LevelData
{
    public int LevelId;
    public bool IsUnblock = false;
    public int Stars;
}

[System.Serializable]
public class VolumeData
{
    public float Volume;
    public bool SoundEnabled = true;
}

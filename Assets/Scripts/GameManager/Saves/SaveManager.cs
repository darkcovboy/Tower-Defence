using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;

public class SaveManager
{
    public int Score => SaveDataWrapper.Score;

    public event Action LoadingFinished;
    public bool IsDataLoaded { get; private set; }

    public SaveDataWrapper SaveDataWrapper { get; private set; }
    private PlayerSave _playerSave;
    private readonly int _maxLevel = 10;
    private ICoroutineRunner _coroutineRunner;

    public SaveManager(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
        IsDataLoaded = false;
        _coroutineRunner.StartCoroutine(Start());
    }

    public void SaveEndLevel(int stars, int score)
    {
        int index = (SceneManager.GetActiveScene().buildIndex - 1);
        SaveDataWrapper.Score += score;

        if (stars > SaveDataWrapper.LevelDataList[index].Stars)
        {
            SaveDataWrapper.LevelDataList[index].Stars = stars;
        }

        if ((index + 1) < _maxLevel)
        {
            SaveDataWrapper.LevelDataList[index + 1].IsUnblock = true;
        }

        SaveData();
    }

    private IEnumerator Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
        _playerSave = new(_maxLevel);
        LoadData();
#elif UNITY_EDITOR
        _playerSave = new(_maxLevel);
        SaveDataWrapper = _playerSave.LoadNewData();
        IsDataLoaded = true;
        LoadingFinished?.Invoke();
        yield break;
#endif
    }

    private async void LoadData()
    {
        Task task = LoadDataTask();
        await task;

        LoadingFinished?.Invoke();
        IsDataLoaded = true;
        SaveData();
    }

    private async Task LoadDataTask()
    {
        string json = null;

        var task = new TaskCompletionSource<string>();

        PlayerAccount.GetCloudSaveData((data) =>
        {
            json = data;
            task.SetResult(data);
        }
        );

        await task.Task;

        if (json != null)
        {
            SaveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(json);
        }
        else
        {
            SaveDataWrapper = _playerSave.LoadNewData();
        }
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(SaveDataWrapper);
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.SetCloudSaveData(json);
#endif
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<LevelData> LevelDataList;
    public int Score;
}

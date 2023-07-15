using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private int _maxLevel;
    [SerializeField] private TextMeshProUGUI _text;
    private SaveDataWrapper _saveDataWrapper;

    private PlayerSave _playerSave;
    private string _jsonData;
    private string _path;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if(PlayerAccount.IsAuthorized == true)
        {
            _playerSave = new PlayerSave(_maxLevel);
            GenerateNewData();
        }
        else
        {
            PlayerAccount.Authorize();
        }
    }

    /*
    public void SaveEndLevel(int stars, int score)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        _saveDataWrapper.levelDataList[index].Score = score;
        _saveDataWrapper.levelDataList[index].Stars = stars;

        if(index + 1 < _maxLevel)
        {
            _saveDataWrapper.levelDataList[index].IsUnblock = true;
        }

        string json = JsonUtility.ToJson(_saveDataWrapper);
        PlayerAccount.SetCloudSaveData(json);
    }
    */

    public void GenerateNewData()
    {
        _saveDataWrapper = _playerSave.LoadRandomData();
        _jsonData = JsonUtility.ToJson(_saveDataWrapper, true);
        _text.text = _jsonData;
    }

    public void LoadData()
    {
        PlayerAccount.GetCloudSaveData((data) => _jsonData = data);
        _text.text = _jsonData;
        _saveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(_jsonData);
        Debug.Log(_saveDataWrapper.levelDataList[0].Score);
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_saveDataWrapper);
        PlayerAccount.SetCloudSaveData(json);
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<LevelData> levelDataList;
    public VolumeData settingsData;
}


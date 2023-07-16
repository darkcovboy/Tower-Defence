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

    public IReadOnlyList<LevelData> LevelData => _saveDataWrapper.levelDataList;

    private SaveDataWrapper _saveDataWrapper;
    private PlayerSave _playerSave;
    private string _jsonData;

    //Старт делаем корутиной, потому что нам обязательно нужно, чтобы сдк загрузилось, проверяем авторизацию, если она есть то создаем стандартный экземпляр класса SaveDataWrapper
    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized == true)
        {
            _playerSave = new PlayerSave(_maxLevel);
            PlayerAccount.GetCloudSaveData((data) => _jsonData = data);

            if (_jsonData == null || _jsonData == "{}")
            {
                GenerateNewData();
            }
            else
            {
                LoadData();
            }
        }
        else
        {
            PlayerAccount.Authorize();
        }
    }

    //Пока не используется, задает новые значения текущему уровню, открываем следующий, сохраняем
    public void SaveEndLevel(int stars, int score)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        _saveDataWrapper.levelDataList[index].Score = score;
        _saveDataWrapper.levelDataList[index].Stars = stars;

        if(index + 1 < _maxLevel)
        {
            _saveDataWrapper.levelDataList[index + 1].IsUnblock = true;
        }

        SaveData();
    }


    //Создаем новую дату, сохраняем, здесь JsonUnitility преобразует наш класс в формат JSON
    public void GenerateNewData()
    {
        _saveDataWrapper = _playerSave.LoadData();
        _jsonData = JsonUtility.ToJson(_saveDataWrapper);
        SaveData();
    }

    //Загружем данные и преобразуем из JSON в класс
    public void LoadData()
    {
        _saveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(_jsonData);
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


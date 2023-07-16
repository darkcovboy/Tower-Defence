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

    //����� ������ ���������, ������ ��� ��� ����������� �����, ����� ��� �����������, ��������� �����������, ���� ��� ���� �� ������� ����������� ��������� ������ SaveDataWrapper
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

    //���� �� ������������, ������ ����� �������� �������� ������, ��������� ���������, ���������
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


    //������� ����� ����, ���������, ����� JsonUnitility ����������� ��� ����� � ������ JSON
    public void GenerateNewData()
    {
        _saveDataWrapper = _playerSave.LoadData();
        _jsonData = JsonUtility.ToJson(_saveDataWrapper);
        SaveData();
    }

    //�������� ������ � ����������� �� JSON � �����
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


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
   public IReadOnlyList<LevelData> LevelData => SaveDataWrapper.levelDataList;

    protected SaveDataWrapper SaveDataWrapper;
    private PlayerSave _playerSave;
    private string _jsonData;
    private readonly int _maxLevel = 10;

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

            UpdateLevels();
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
        SaveDataWrapper.Score += score;
        SaveDataWrapper.levelDataList[index].Stars = stars;

        if(index + 1 < _maxLevel)
        {
            SaveDataWrapper.levelDataList[index + 1].IsUnblock = true;
        }

        SaveData();
    }

    protected virtual void UpdateLevels()
    {

    }


    //������� ����� ����, ���������, ����� JsonUnitility ����������� ��� ����� � ������ JSON
    private void GenerateNewData()
    {
        SaveDataWrapper = _playerSave.LoadData();
        _jsonData = JsonUtility.ToJson(SaveDataWrapper);
        SaveData();
    }

    //�������� ������ � ����������� �� JSON � �����
    private void LoadData()
    {
        SaveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(_jsonData);
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(SaveDataWrapper);
        PlayerAccount.SetCloudSaveData(json);
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<LevelData> levelDataList;
    public VolumeData settingsData;
    public int Score;
}


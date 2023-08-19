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
    [SerializeField] private AudioManager _audioManager;

    public int Score => SaveDataWrapper.Score; 

    protected SaveDataWrapper SaveDataWrapper;
    private PlayerSave _playerSave;
    private string _jsonData;
    private readonly int _maxLevel = 10;
    private readonly string _dataPrefsKey = "GameDataJSON";

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
        _playerSave = new(_maxLevel);

        if (PlayerPrefs.HasKey(_dataPrefsKey))
        {
            Debug.Log("���� ����");
            _jsonData = PlayerPrefs.GetString(_dataPrefsKey);
            SaveDataWrapper = JsonUtility.FromJson<SaveDataWrapper>(_jsonData);
            SaveData();
        }
        else
        {
            Debug.Log("��� �����");
            GenerateNewData();
        }
    }

    public void Init(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    //���� �� ������������, ������ ����� �������� �������� ������, ��������� ���������, ���������
    public void SaveEndLevel(int stars, int score)
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SaveDataWrapper.Score += score;

        if (stars > SaveDataWrapper.LevelDataList[index].Stars)
        {
            SaveDataWrapper.LevelDataList[index].Stars = stars;
        }

        SaveDataWrapper.SettingsData.SoundEnabled = AudioListener.pause;
        SaveDataWrapper.SettingsData.Volume = AudioListener.volume;

        if ((index + 1) < _maxLevel)
        {
            SaveDataWrapper.LevelDataList[index + 1].IsUnblock = true;
        }

        SaveData();
    }

    protected virtual void UpdateLevels()
    {
        _audioManager.OnSliderChanged(SaveDataWrapper.SettingsData.Volume);
        _audioManager.AudioChange(SaveDataWrapper.SettingsData.SoundEnabled);
    }


    //������� ����� ����, ���������, ����� JsonUnitility ����������� ��� ����� � ������ JSON
    private void GenerateNewData()
    {
        SaveDataWrapper = _playerSave.LoadData();
        _jsonData = JsonUtility.ToJson(SaveDataWrapper);
        SaveData();
    }

    private void SaveData()
    {
        Debug.Log(_jsonData);
        _jsonData = JsonUtility.ToJson(SaveDataWrapper);
        PlayerPrefs.SetString(_dataPrefsKey, _jsonData);
        PlayerPrefs.Save();
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<LevelData> LevelDataList;
    public VolumeData SettingsData;
    public int Score;
}

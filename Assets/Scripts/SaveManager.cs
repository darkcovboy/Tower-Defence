using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private int _maxLevel;
    private PlayerSave _playerSave;
    private SaveDataWrapper _saveDataWrapper;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        PlayerAccount.Authorize();

        if(PlayerAccount.IsAuthorized == true)
        {
            _playerSave = new PlayerSave(_maxLevel);

            PlayerAccount.GetCloudSaveData(OnSuccessData, OnErrorData);
        }
    }

    public void Save()
    {

    }

    private void OnSuccessData(string data)
    {
        _saveDataWrapper = _playerSave.LoadData(data);
        AudioListener.volume = _saveDataWrapper.settingsData.Volume;
        AudioListener.pause = _saveDataWrapper.settingsData.SoundEnabled;
    }

    private void OnErrorData(string data)
    {
        _playerSave.LoadData();
    }
}

[System.Serializable]
public class SaveDataWrapper
{
    public List<LevelData> levelDataList;
    public VolumeData settingsData;
}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private LevelButton[] _levelButtons;

    private LoadingPanel _loadingPanel;

    private SaveManager _saveManager;

    [Inject]
    public void Init(LoadingPanel loadingPanel, SaveManager saveManager)
    {
        _loadingPanel = loadingPanel;
        _saveManager = saveManager;
    }

    private void Start()
    {
        if(_saveManager.IsDataLoaded == false)
        {
            _saveManager.LoadingFinished += UpdateLevels;
        }
        else
        {
            UpdateLevels();
        }

    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(CloseObject);

    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(CloseObject);
    }

    public void UpdateLevels()
    {
        List<LevelData> levelDatas = _saveManager.SaveDataWrapper.LevelDataList;

        Debug.Log(levelDatas[1].LevelId);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            int index = i;
            _levelButtons[i].UnblockButton(levelDatas[i].IsUnblock);
            _levelButtons[i].UpdateStars(levelDatas[i].Stars);
            _levelButtons[i].Button.onClick.AddListener(() => _loadingPanel.LoadLevel(_levelButtons[index].LevelName));
        }
    }

    private void CloseObject() => gameObject.SetActive(false);
}

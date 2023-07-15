using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class LevelSelect : MonoBehaviour
{
    // ��� ����� �� ���������, ��� �� ���� �������� ������� ������ � ���� �����, � ����� ��� ������� ����� ��������� � ������� �� ��� ���������, ��� ����� ������.
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Button[] _levelButtons;

    public void UpdateLevels(List<LevelData> levelDatas)
    {
        for(int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].interactable = levelDatas[i].IsUnblock;
            _levelButtons[i].GetComponent<LevelButton>().UpdateStars(levelDatas[i].Stars);
        }
    }

    public void Select(string levelName)
    {
        _sceneFader.FadeTo(levelName);
    }
}

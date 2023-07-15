using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class LevelSelect : MonoBehaviour
{
    // Мне очень не нравилось, что мы ищем дочерние объекты кнопок в виде звезд, я решил это сделать более нормально и повесил на них компонент, где задал звезды.
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

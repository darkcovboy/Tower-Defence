using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Button[] _levelButtons;
    [SerializeField] private Sprite _star;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                _levelButtons[i].interactable = false;
        }

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (PlayerPrefs.HasKey("stars" + i))
            {
                if (PlayerPrefs.GetInt("stars" + i) == 1)
                {
                    _levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("stars" + i) == 2)
                {
                    _levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                    _levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    _levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                    _levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                    _levelButtons[i].transform.GetChild(3).gameObject.SetActive(true);
                }
            }
        }
    }

    public void Select(string levelName)
    {
        _sceneFader.FadeTo(levelName);
    }
}

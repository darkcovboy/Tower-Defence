using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryBook : MonoBehaviour
{
    [SerializeField] private GameObject[] _bookPage;
    [Header("UI Enemy")]
    [SerializeField] private Image _enemyDefaultSprite;
    [SerializeField] private TMP_Text _enemyDefaultName;

    public void OpenPage(int indexPage)
    {
        for (int i = 0; i < _bookPage.Length; i++)
        {
            if (i == indexPage)
            {
                _bookPage[i].SetActive(true);
            }
            else
                _bookPage[i].SetActive(false);
        }
    }

    public void ChoosEnemy(Sprite enemySprite,TMP_Text enemyName)
    {
        _enemyDefaultSprite.sprite = enemySprite;
        _enemyDefaultName.text = enemyName.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryBook : MonoBehaviour
{
    [SerializeField] private GameObject[] _bookPage;
    [Header("UI Enemy Parametrs")]
    [SerializeField] private Image _enemyDefaultSprite;
    [SerializeField] private TMP_Text _enemyDefaultName;
    [SerializeField] private TMP_Text _enemyHealthText;
    [SerializeField] private TMP_Text _enemyDamageText;
    [SerializeField] private TMP_Text _enemyRewardText;
    [SerializeField] private TMP_Text _enemySpeedText;
    [Header("UI Tower Parametrs")]
    [SerializeField] private Image _towerSprite;
    [SerializeField] private TMP_Text _towerDefaultName;
    [SerializeField] private TMP_Text _towerDamageText;
    [SerializeField] private TMP_Text _towerDelayText;

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

    public void ChoosEnemy(Sprite enemySprite,TMP_Text enemyName, int health, int damage, float speed, int reward)
    {
        _enemyDefaultSprite.sprite = enemySprite;
        _enemyDefaultName.text = enemyName.text;
        _enemyHealthText.text = health.ToString();
        _enemyDamageText.text = damage.ToString();
        _enemyRewardText.text = reward.ToString();
        _enemySpeedText.text = speed.ToString();
    }

    public void ChooseTower(Sprite towerSprite,TMP_Text towerName,int damageTower,float delay)
    {
        _towerSprite.sprite = towerSprite;
        _towerDefaultName.text = towerName.text;
        _towerDamageText.text = damageTower.ToString();
        _towerDelayText.text = delay.ToString();
    }
}

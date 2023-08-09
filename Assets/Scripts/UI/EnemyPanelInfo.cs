using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanelInfo : MonoBehaviour
{
    [Header("UI Enemy Parametrs")]
    [SerializeField] private Image _enemyDefaultSprite;
    [SerializeField] private TMP_Text _enemyDefaultName;
    [SerializeField] private TMP_Text _enemyDescription;
    [SerializeField] private TMP_Text _enemyHealthText;
    [SerializeField] private TMP_Text _enemyDamageText;
    [SerializeField] private TMP_Text _enemyRewardText;
    [SerializeField] private TMP_Text _enemySpeedText;

    public void ChoosEnemy(Sprite enemySprite, TMP_Text enemyName, TMP_Text description, int health, int damage, float speed, int reward)
    {
        _enemyDefaultSprite.sprite = enemySprite;
        _enemyDefaultName.text = enemyName.text;
        _enemyDescription.text = description.text;
        _enemyHealthText.text = health.ToString();
        _enemyDamageText.text = damage.ToString();
        _enemyRewardText.text = reward.ToString();
        _enemySpeedText.text = speed.ToString();
    }
}

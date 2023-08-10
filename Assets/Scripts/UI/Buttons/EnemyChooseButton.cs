using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyChooseButton : AbstractButton
{
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private EnemyPanelInfo _enemyInfo;
    [SerializeField] private Sprite _enemySprite;
    [SerializeField] private TMP_Text _enemyName;
    [SerializeField] private TMP_Text _description;

    protected override void OnButtonClick()
    {
        _enemyInfo.ChoosEnemy(_enemySprite,_enemyName,_description,_enemyConfig.Health,_enemyConfig.Damage,_enemyConfig.Speed,_enemyConfig.Reward);
    }
}

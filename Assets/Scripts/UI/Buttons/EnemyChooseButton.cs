using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyChooseButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook; 
    [SerializeField] private Sprite _enemySprite;
    [SerializeField]private TMP_Text _enemyName;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private int _enemyDamage;
    [SerializeField] private int _enemyReward;
    [SerializeField] private float _enemySpeed;
    //[SerializeField] private Image _imageFrame;

    protected override void OnButtonClick()
    {
        _bestiaryBook.ChoosEnemy(_enemySprite, _enemyName, _enemyHealth, _enemyDamage,_enemySpeed,_enemyReward);
        //_imageFrame.color = Color.green;
    }
}

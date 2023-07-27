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
    //[SerializeField] private Image _imageFrame;

    protected override void OnButtonClick()
    {
        _bestiaryBook.ChoosEnemy(_enemySprite, _enemyName);
        //_imageFrame.color = Color.green;
    }
}

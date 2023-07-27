using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTowerButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private Sprite _towerImage;
    [SerializeField] private TMP_Text _towerName;
    [SerializeField] private int _towerDamage;
    [SerializeField] private float _towerDelay;

    protected override void OnButtonClick()
    {
        _bestiaryBook.ChooseTower(_towerImage, _towerName, _towerDamage, _towerDelay);
    }
}

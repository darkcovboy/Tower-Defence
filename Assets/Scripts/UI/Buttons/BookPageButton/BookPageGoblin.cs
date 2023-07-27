using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPageGoblin : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private int _indexBookPage;

    private int _indexPageGoblin = 1;

    protected override void OnButtonClick()
    {
        Debug.Log(_indexBookPage);
        _bestiaryBook.OpenPage(_indexBookPage);
    }
}

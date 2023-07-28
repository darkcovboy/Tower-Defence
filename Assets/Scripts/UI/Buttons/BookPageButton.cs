using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPageButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private int _indexBookPage;

    protected override void OnButtonClick()
    {
        _bestiaryBook.OpenPage(_indexBookPage);
    }
}

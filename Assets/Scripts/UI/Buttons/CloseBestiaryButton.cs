using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBestiaryButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;

    protected override void OnButtonClick()
    {
        _bestiaryBook.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

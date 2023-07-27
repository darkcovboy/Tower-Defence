using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;

    protected override void OnButtonClick()
    {
        _bestiaryBook.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

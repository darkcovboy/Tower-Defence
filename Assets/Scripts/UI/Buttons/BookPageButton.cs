using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPageButton : AbstractButton
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private int _indexBookPage;

    protected override void OnButtonClick()
    {
        _audioSource.PlayOneShot(_audioClip);
        _bestiaryBook.OpenPage(_indexBookPage);
    }
}

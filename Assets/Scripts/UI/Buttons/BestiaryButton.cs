using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;
    [SerializeField] private GameObject[] _screenPanels;
    [SerializeField] private CameraRotate _cameraRotate;

    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        AudioSource.Play();
        foreach (var screen in _screenPanels)
        {
            screen.gameObject.SetActive(false);
        }
        _bestiaryBook.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryButton : AbstractButton
{
    [SerializeField] private BestiaryBook _bestiaryBook;

    [SerializeField] private CameraRotate _cameraRotate;

    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        _bestiaryBook.gameObject.SetActive(true);
    }
}

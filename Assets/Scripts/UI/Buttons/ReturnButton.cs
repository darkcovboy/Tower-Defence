using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : AbstractButton
{
    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }

    protected override void OnButtonClick()
    {
        AudioSource.Play(AudioDataProperty.Key);
        _cameraRotate.ReturnCameraDefault();
    }
}

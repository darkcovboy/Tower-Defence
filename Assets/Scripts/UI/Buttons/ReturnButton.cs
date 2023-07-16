using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : AbstractButton
{
    [SerializeField] private GameObject[] _screens;

    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }

    protected override void OnButtonClick()
    {
        _cameraRotate.ReturnCameraDefault();

        foreach (var screen in _screens)
        {
            screen.SetActive(false);
        }
    }
}

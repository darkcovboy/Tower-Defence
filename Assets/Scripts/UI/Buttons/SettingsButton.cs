using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;

    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }

    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        _settingsScreen.gameObject.SetActive(true);
    }
}

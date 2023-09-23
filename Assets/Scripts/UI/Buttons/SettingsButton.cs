using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private GameObject[] _screenPanels;

    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }

    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        gameObject.GetComponent<AudioSource>().Play();

        foreach (var screen in _screenPanels)
        {
            screen.gameObject.SetActive(false);
        }
        _settingsScreen.gameObject.SetActive(true);
    }
}

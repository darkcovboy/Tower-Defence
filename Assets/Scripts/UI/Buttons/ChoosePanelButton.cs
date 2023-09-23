using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePanelButton : AbstractButton
{
    [SerializeField] private GameObject[] _screenPanels;
    [SerializeField] private int _numberButton;

    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }

    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        gameObject.GetComponent<AudioSource>().Play();

        for (int i = 0; i < _screenPanels.Length; i++)
        {
            if (i == _numberButton)
                _screenPanels[i].gameObject.SetActive(true);
            else
                _screenPanels[i].gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : AbstractButton
{
    [SerializeField]private LevelSelectPanel _levelSelectPanel;
    private CameraRotate _cameraRotate;

    private void Start()
    {
        _cameraRotate = FindObjectOfType<CameraRotate>();
    }
    protected override void OnButtonClick()
    {
        _cameraRotate.ChangeDirection();
        _levelSelectPanel.gameObject.SetActive(true);
    }
}

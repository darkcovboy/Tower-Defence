using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : AbstractButton
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _direction;

    private float _speedRotation = 30;

    private void Start()
    {
        _direction.rotation = Camera.main.transform.rotation;
        //_direction.position = Camera.main.transform.position;
    }

    private void Update()
    {
        if (Camera.main.transform.rotation != _direction.rotation)
            ChangeRotateCamera();
    }

    protected override void OnButtonClick()
    {
        _direction.rotation = _canvas.transform.rotation;
        //_direction.position = new Vector3(_canvas.transform.position.x, Camera.main.transform.position.y, _canvas.transform.position.z);
    }

    private void ChangeRotateCamera()
    {
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, _direction.rotation, _speedRotation * Time.deltaTime);
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _direction.position, _speed * Time.deltaTime);
    }
}

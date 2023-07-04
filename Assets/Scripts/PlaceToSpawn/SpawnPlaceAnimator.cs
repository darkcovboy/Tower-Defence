using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _choicePanel;

    private Animator _animator;

    private readonly string _isOpened = "IsOpened";

    private void Start()
    {
        _animator = _choicePanel.GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool(_isOpened, true);
    }

    public void Close()
    {
        _animator.SetBool(_isOpened, false);
    }
}

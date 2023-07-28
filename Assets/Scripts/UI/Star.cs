using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
   [SerializeField] private Animator _animator;
    //[SerializeField] private AudioSource _audioSource;
    //[SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetBool("Star", true);
    }

    //public void PlayAudio()
    //{
    //    _audioSource.PlayOneShot(_audioClip);
    //}
}

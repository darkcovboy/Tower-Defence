using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class Star : MonoBehaviour
{
   [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetBool("Star", true);
        gameObject.GetComponent<AudioSource>().Play();
    }
}

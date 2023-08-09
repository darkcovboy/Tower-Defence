using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestiaryBook : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject[] _bookPage;

    private void OnEnable()
    {
        _audioSource.PlayOneShot(_audioClip);
        OpenPage(0);
    }

    public void OpenPage(int indexPage)
    {
        for (int i = 0; i < _bookPage.Length; i++)
        {
            if (i == indexPage)
            {
                _bookPage[i].SetActive(true);
            }
            else
                _bookPage[i].SetActive(false);
        }
    }
}

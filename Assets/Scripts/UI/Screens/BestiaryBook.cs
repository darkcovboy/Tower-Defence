using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestiaryBook : MonoBehaviour
{
    [SerializeField] private GameObject[] _bookPage;

    private void Start()
    {
        
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

    public void ClosePages()
    {

    }
}

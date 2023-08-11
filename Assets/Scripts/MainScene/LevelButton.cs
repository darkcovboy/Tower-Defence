using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;

    public void UpdateStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _stars[i].Activate();
        }
    }
}

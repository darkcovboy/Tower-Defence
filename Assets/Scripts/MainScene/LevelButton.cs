using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private BlockButton _blockButton;

    public void UnblockButton(bool isButtonOpened)
    {
        if(isButtonOpened == true)
            _blockButton.Deactivate();
        else
            _blockButton.Activate();
    }

    public void UpdateStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _stars[i].Activate();
        }
    }
}

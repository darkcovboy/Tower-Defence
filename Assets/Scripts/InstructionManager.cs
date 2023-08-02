using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    private readonly float _offTime = 0f;
    private readonly float _standartTime = 1f;

    private void OnEnable()
    {
        Time.timeScale = _offTime;
    }

    public void StartGame()
    {
        Time.timeScale = _standartTime;
    }
}

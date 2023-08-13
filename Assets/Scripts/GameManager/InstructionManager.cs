using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    private readonly float _offTime = 0f;
    private readonly float _standartTime = 1f;

    private void OnEnable()
    {
        _sceneFader.FadeInCompleted += StopGame;
    }

    private void OnDisable()
    {
        _sceneFader.FadeInCompleted -= StopGame;
    }

    public void StartGame()
    {
        Time.timeScale = _standartTime;
    }

    private void StopGame()
    {
        Time.timeScale = _offTime;
    }
}

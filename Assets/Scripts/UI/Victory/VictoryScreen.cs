using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    private CanvasGroup _victoryCanvasGroup;
    [SerializeField] private TestSpawner _testSpawner;

    private void OnEnable()
    {
        _testSpawner.AllEnemysDied += OnScreenVictory;
    }

    private void OnDisable()
    {
        _testSpawner.AllEnemysDied -= OnScreenVictory;
    }


    private void Start()
    {
        _victoryCanvasGroup = GetComponent<CanvasGroup>();
        OnOrOffScreen(false, 0);
        Time.timeScale = 1;
    }

    public void OnScreenVictory()
    {
        Time.timeScale = 0;
        OnOrOffScreen(true, 1);
    }

    private void OnOrOffScreen(bool flag,int numberAlphaCanvas)
    {
        _victoryCanvasGroup.interactable = flag;
        _victoryCanvasGroup.alpha = numberAlphaCanvas;
        _victoryCanvasGroup.blocksRaycasts = flag;
    }
}

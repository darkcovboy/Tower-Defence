using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private CanvasGroup _victoryCanvasGroup;


    private void OnEnable()
    {
        _spawner.AllEnemysDied += OnScreenVictory;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OnScreenVictory;
    }


    private void Start()
    {
        _victoryCanvasGroup = GetComponent<CanvasGroup>();
        OnOrOffScreen(false, 0);
        Time.timeScale = 1;
    }

    public void OnScreenVictory()
    {
        WinLevel();
        Time.timeScale = 0;
        OnOrOffScreen(true, 1);
    }

    private void OnOrOffScreen(bool flag, int numberAlphaCanvas)
    {
        _victoryCanvasGroup.interactable = flag;
        _victoryCanvasGroup.alpha = numberAlphaCanvas;
        _victoryCanvasGroup.blocksRaycasts = flag;
    }

    private void WinLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;
        var numberCompliteLevels = PlayerPrefs.GetInt("levelReached");

        if (currentLevel < numberCompliteLevels)
        {
            return;
        }
        else
            PlayerPrefs.SetInt("levelReached", ++currentLevel);
    }
}

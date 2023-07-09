using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : Screen
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _screen;

    private ObjectManagerUI _objectManager;

    private void Awake()
    {
        //_objectManager = FindObjectOfType<ObjectManagerUI>();
    }

    private void OnEnable()
    {
        //_objectManager.CloseUI();
        _spawner.AllEnemysDied += OpenScreen;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OpenScreen;
    }

    public override void OpenScreen()
    {
        WinLevel();
        _screen.SetActive(true);
        Time.timeScale = 0;
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

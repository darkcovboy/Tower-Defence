using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : Screen
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _screen;
    //[SerializeField] private TextMeshProUGUI _pointsText;

    private ObjectManagerUI _objectManager;

    private void OnEnable()
    {
        _spawner.AllEnemysDied += OpenScreen;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OpenScreen;
    }

    public void Init(ObjectManagerUI objectManagerUI)
    {
        _objectManager = objectManagerUI;
    }

    public override void OpenScreen()
    {
        Time.timeScale = 0;
       //_objectManager.CloseUI();
        WinLevel();
        _screen.SetActive(true);
        Debug.Log("Screen");
    }

    public void SetScore(float points)
    {
        //_pointsText.text = points.ToString();
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

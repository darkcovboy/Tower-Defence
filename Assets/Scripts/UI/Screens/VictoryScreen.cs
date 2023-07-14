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
    //[SerializeField] private GameObject[] _stars;
    [SerializeField] private Star[] _stars;

    private Player _player;
    private int _countStars;
    //[SerializeField] private TextMeshProUGUI _pointsText;

    //private ObjectManagerUI _objectManager;

    private void Awake()
    {
        //_objectManager = FindObjectOfType<ObjectManagerUI>();
        _player = FindObjectOfType<Player>();
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
        //Time.timeScale = 0;
        WinLevel();
        GetStarsCount();
        SetStars();
        _screen.SetActive(true);
        StartCoroutine(ShowStars());
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

    private void SetStars()
    {
        if (_player.CurrentHealth <= 50 && !PlayerPrefs.HasKey("stars" + SceneManager.GetActiveScene().buildIndex))
        {
            PlayerPrefs.SetInt("stars" + SceneManager.GetActiveScene().buildIndex, 1);
        }
        else if (_player.CurrentHealth <= 80 && _player.CurrentHealth > 50 && (!PlayerPrefs.HasKey("stars" + SceneManager.GetActiveScene().buildIndex) || PlayerPrefs.GetInt("stars" + SceneManager.GetActiveScene().buildIndex) < 2))
        {
            PlayerPrefs.SetInt("stars" + SceneManager.GetActiveScene().buildIndex, 2);
        }
        else if (_player.CurrentHealth >= 81 && (!PlayerPrefs.HasKey("stars" + SceneManager.GetActiveScene().buildIndex) || PlayerPrefs.GetInt("stars" + SceneManager.GetActiveScene().buildIndex) < 3))
        {
            PlayerPrefs.SetInt("stars" + SceneManager.GetActiveScene().buildIndex, 3);
        }
    }

    private void GetStarsCount()
    {
        if (_player.CurrentHealth >= 81)
            _countStars = 3;
        else if (_player.CurrentHealth <= 80 && _player.CurrentHealth > 50)
            _countStars = 2;
        else
            _countStars = 1;
    }

    IEnumerator ShowStars()
    {
        for (int i = 0; i < _countStars; i++)
        {
            yield return new WaitForSeconds(1);
            _stars[i].gameObject.SetActive(true);
            _stars[i].PlayAnimation();
        }
    }
}

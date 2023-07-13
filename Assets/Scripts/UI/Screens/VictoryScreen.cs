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
    [SerializeField] private List<GameObject> _stars;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private ObjectManagerUI _objectManager;
    private readonly int _maxAlpha = 255;

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
       _objectManager.CloseUI();
        WinLevel();
        _screen.Activate();
    }

    public void SetScore(float points)
    {
       _pointsText.text = points.ToString();
    }

    public void SetStars(int index)
    {
        for (int i = 0; i < index; i++)
        {
            StartCoroutine(StarsFill(i));
        }
    }

    private IEnumerator StarsFill(int index)
    {
        _stars[index].Activate();
        var image = _stars[index].gameObject.GetComponent<Image>();
        Color color = image.color;

        for (int i = 0; i < _maxAlpha; i++)
        {
            color.a = i;
            image.color = color;
            yield return null;
        }
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

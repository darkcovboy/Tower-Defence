using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class VictoryScreen : Screen
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Star[] _stars;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private int _countStars;

    private void OnEnable()
    {
        _spawner.AllEnemysDied += OpenScreen;
    }

    private void OnDisable()
    {
        _spawner.AllEnemysDied -= OpenScreen;
    }

    public override void OpenScreen()
    {
        _screen.SetActive(true);

    }

    public void SetScore(float points)
    {
        _pointsText.text = points.ToString();
    }

    public void SetStars(int stars)
    {
        //for (int i = 0; i < stars; i++)
        //{
        //    _stars[i].Activate();
        //}
        //_countStars = stars;
        StartCoroutine(ShowStars(stars));
    }

    IEnumerator ShowStars(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            yield return new WaitForSeconds(1);
            _stars[i].Activate();
            _stars[i].PlayAnimation(); 
        }
    }
}

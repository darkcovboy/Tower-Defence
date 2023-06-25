using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;

    public void Select(string levelName)
    {
        _sceneFader.FadeTo(levelName);
    }
}

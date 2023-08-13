using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _loadingBarFill;

    public void LoadScene(string sceneName)
    {
        _loadingScreen.Activate();
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        _loadingScreen.Activate();

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            _loadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}

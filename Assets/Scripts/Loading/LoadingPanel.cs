using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    private const float MaxLoading = 1f;
    private const float LoadDelimetr = 0.9f;

    [SerializeField] private Slider _loadingBar;

    public static LoadingPanel Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        gameObject.Deactivate();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Restart()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string levelName)
    {
        Debug.Log(levelName);
        gameObject.Activate();
        StartCoroutine(LoadSceneAsync(levelName));
    }

    private IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        _loadingBar.maxValue = MaxLoading;

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / LoadDelimetr);

            _loadingBar.value = progressValue;

            yield return null;
        }

        gameObject.Deactivate();
    }
}

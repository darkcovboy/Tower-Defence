using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _curve;

    private FullVideo _fullVideo;

    public event UnityAction FadeInCompleted;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(FadeIn());
    }

    public void Init(FullVideo fullVideo)
    {
        _fullVideo = fullVideo;
    }

    public void FadeTo(string nameScene)
    {
        StartCoroutine(FadeOut(nameScene));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime * Time.timeScale;
            float a = _curve.Evaluate(time);
            _image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        FadeInCompleted?.Invoke();
    }

    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * Time.timeScale;
            float alpha = _curve.Evaluate(time);
            _image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}

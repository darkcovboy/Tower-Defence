using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _playImage;
    [SerializeField] private Image _loadingImage;

    private SaveManager _container;

    [Inject]
    public void Constructor(SaveManager saveManager)
    {
        _container = saveManager;
        _container.LoadingFinished += OnLoadedFinish;
    }

    private void OnValidate()
    {
        if(_button == null)
            _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.interactable = false;

        if (_container.IsDataLoaded == false)
        {
            StartCoroutine(RotateLoading());
        }
        else
        {
            OnLoadedFinish();
        }
    }

    public void OnLoadedFinish()
    {
        _button.interactable = true;
        _playImage.enabled = true;
        _loadingImage.enabled = false;
    }

    private IEnumerator RotateLoading()
    {
        while(_loadingImage.enabled)
        {
            _loadingImage.transform.Rotate(0f,0f,2f);
            yield return new WaitForSeconds(0.05f);
        }
    }

}

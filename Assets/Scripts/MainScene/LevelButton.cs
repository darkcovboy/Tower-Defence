using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private BlockButton _blockButton;

    public string LevelName => _levelName;
    public Button Button => _button;

    private void OnValidate()
    {
        if(_button == null)
            _button = GetComponent<Button>();
    }

    public void AddListener(UnityAction<string> load)
    {
        _button.onClick.AddListener(() => load?.Invoke(_levelName));
    }

    public void UnblockButton(bool isButtonOpened)
    {
        if(isButtonOpened == true)
            _blockButton.Deactivate();
        else
            _blockButton.Activate();
    }

    public void UpdateStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _stars[i].Activate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    private const float MaxVolume = 1.0f;
    private const float MinVolume = 0f;

    [SerializeField] private Sprite _onMusicSprite;
    [SerializeField] private Sprite _offMusicSprite;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(SwapMusic);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwapMusic);
    }

    private void SwapMusic()
    {
        if(AudioListener.pause == false)
        {
            AudioListener.pause = true;
            AudioListener.volume = MinVolume;
            _musicImage.sprite = _offMusicSprite;
        }
        else
        {
            AudioListener.pause = false;
            AudioListener.volume = MaxVolume;
            _musicImage.sprite = _onMusicSprite;
        }
    }
}

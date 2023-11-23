using UnityEngine;
using UnityEngine.UI;

public class PauseButton : AbstractButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _pauseSprite;
    [SerializeField] private Sprite _playSprite;
    protected override void OnButtonClick()
    {
        if(Time.timeScale == 1)
        {
            _image.sprite = _playSprite;
            Time.timeScale = 0;
        }
        else
        {
            _image.sprite = _pauseSprite;
            Time.timeScale = 1;
        }
    }
}

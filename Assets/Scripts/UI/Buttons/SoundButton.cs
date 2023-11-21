using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource _button;
    [SerializeField] private AudioSource _nextWaveButton;

    public void Play()
    {
        _button.Play();
    }

    public void PlayNextWave()
    {
        _nextWaveButton.Play();
    }
}

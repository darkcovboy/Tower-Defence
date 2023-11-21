using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ADButtonHealth : MonoBehaviour
{
    [SerializeField] private Button _button;

    private SoundButton _soundButton;
    private RewardedHealthVideo _rewardVideo;
    private TimeToSpawnNextWaveScreen _nextWaveScreen;

    [Inject]
    public void Init(SoundButton soundButton, RewardedHealthVideo rewardedHealthVideo, TimeToSpawnNextWaveScreen timeToSpawnNextWaveScreen)
    {
        _soundButton = soundButton;
        _rewardVideo = rewardedHealthVideo;
        _nextWaveScreen = timeToSpawnNextWaveScreen;
    }

    private void OnValidate()
    {
        if (_button == null )
            _button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_soundButton.Play);
        _button.onClick.AddListener(_rewardVideo.Show);
        _button.onClick.AddListener(_nextWaveScreen.SetPlayerAlive);
        _button.onClick.AddListener(gameObject.Deactivate);
        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_soundButton.Play);
        _button.onClick.RemoveListener(_rewardVideo.Show);
        _button.onClick.RemoveListener(_nextWaveScreen.SetPlayerAlive);
        _button.onClick.RemoveListener(gameObject.Deactivate);
    }
}

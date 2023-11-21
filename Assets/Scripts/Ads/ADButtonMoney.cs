using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ADButtonMoney : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _moneyText;

    private SoundButton _soundButton;
    private RewardedMoneyVideo _rewardedVideo;

    [Inject]
    public void Init(SoundButton soundButton, RewardedMoneyVideo rewardedMoneyVideo)
    {
        _soundButton = soundButton;
        _rewardedVideo = rewardedMoneyVideo;
    }

    private void Start()
    {
        StartCoroutine(OnTimeGoing());
    }

    private void OnValidate()
    {
        if (_button == null)
            _button = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_soundButton.Play);
        _button.onClick.AddListener(_rewardedVideo.Show);
        _button.onClick.AddListener(gameObject.Deactivate);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_soundButton.Play);
        _button.onClick.RemoveListener(_rewardedVideo.Show);
        _button.onClick.RemoveListener(gameObject.Deactivate);
    }

    private IEnumerator OnTimeGoing()
    {
        gameObject.Deactivate();
        yield return new WaitForSeconds(25f);
        gameObject.Activate();
    }
}

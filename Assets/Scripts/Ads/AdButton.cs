using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdButton : MonoBehaviour
{
    [SerializeField] private ShowType adType;
    [SerializeField] private TextMeshProUGUI _moneyText;
    
    private int _money;

    public void Init(int money, RewardedVideo rewardedVideo)
    {
        _money = money;
        _moneyText.text = _money.ToString();
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(gameObject.Deactivate);
    }

    public void Init(/*RewardedVideo rewardedVideo,*/Player player, GameOverScreen gameOverScreen)
    {
        var button = gameObject.GetComponent<Button>();
        //button.onClick.AddListener(() => rewardedVideo.Show(adType));
        button.onClick.AddListener(() => player.AddExtraLive(100));
        button.onClick.AddListener(gameOverScreen.CloseScreen);
        button.onClick.AddListener(gameObject.Deactivate);
    }
}

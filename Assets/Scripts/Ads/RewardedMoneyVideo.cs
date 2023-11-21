using Zenject;

public class RewardedMoneyVideo : RewardedVideo
{
    private MoneyCounter _moneyCounter;

    private int _adMoney;

    [Inject]
    public void Init(MoneyCounter moneyCounter)
    {
        _moneyCounter = moneyCounter;
    }

    public RewardedMoneyVideo(int money)
    {
        _adMoney = money;
    }

    protected override void OnRewardedCallback()
    {
        _moneyCounter.AddMoney(_adMoney);
    }
}

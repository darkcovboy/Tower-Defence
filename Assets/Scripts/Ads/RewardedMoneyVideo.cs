using Zenject;

public class RewardedMoneyVideo : RewardedVideo
{
    private MoneyCounter _moneyCounter;

    public int ADMoney { get; private set; }

    [Inject]
    public void Init(MoneyCounter moneyCounter)
    {
        _moneyCounter = moneyCounter;
    }

    public RewardedMoneyVideo(int money)
    {
        ADMoney = money;
    }

    protected override void OnRewardedCallback()
    {
        _moneyCounter.AddMoney(ADMoney);
    }
}

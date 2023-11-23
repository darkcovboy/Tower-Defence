public class NextWaveButton : AbstractButton
{
    private SoundButton _soundButton;
    private MoneyCounter _moneyCounter;
    private TimeToSpawnNextWaveScreen _timerToSpawnNextWave;

    public void Init(MoneyCounter moneyCounter, SoundButton soundButton, TimeToSpawnNextWaveScreen timeToSpawnNextWaveScreen)
    {
        _soundButton = soundButton;
        _moneyCounter = moneyCounter;
        _timerToSpawnNextWave = timeToSpawnNextWaveScreen;
    }

    protected override void OnButtonClick()
    {
        _moneyCounter.AddMoney(15);
        _soundButton.PlayNextWave();
        _timerToSpawnNextWave.ResetTimer();
    }
}

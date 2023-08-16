using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveButton : AbstractButton
{
    [SerializeField] private TimeToSpawnNextWaveScreen _timerToSpawnNextWave;

    private SoundButton _soundButton;
    private MoneyCounter _moneyCounter;

    public void Init(MoneyCounter moneyCounter, SoundButton soundButton)
    {
        _soundButton = soundButton;
        _moneyCounter = moneyCounter;
    }

    protected override void OnButtonClick()
    {
        _moneyCounter.AddMoney(15);
        _soundButton.PlayNextWave();
        _timerToSpawnNextWave.ResetTimer();
    }
}

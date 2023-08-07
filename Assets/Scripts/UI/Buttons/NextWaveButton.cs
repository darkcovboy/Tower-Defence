using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveButton : AbstractButton
{
    [SerializeField] private TimeToSpawnNextWaveScreen _timerToSpawnNextWave;
    [SerializeField] private MoneyCounter _moneyCounter;

    protected override void OnButtonClick()
    {
        _moneyCounter.AddMoney(15);
        AudioSource.Play();
        _timerToSpawnNextWave.ResetTimer();
    }
}

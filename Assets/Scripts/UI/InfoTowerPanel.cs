using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTowerPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void SendData(int damage, float time)
    {
        _damageText.text = damage.ToString();
        _timeText.text = time.ToString();
    }

    public void SendData(int damage,float time, int health)
    {
        _damageText.text = damage.ToString();
        _timeText.text = time.ToString();
        _healthText.text = health.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class InfoTowerPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _titleText;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _healthText;

    public void SendData(int damage, float time, LeanPhrase title, LeanPhrase description)
    {
        _damageText.text = damage.ToString();
        _timeText.text = time.ToString();
        _titleText.TranslationName = title.name;
        _descriptionText.TranslationName = description.name;
    }

    public void SendData(int damage,float time, int health, LeanPhrase title, LeanPhrase description)
    {
        _damageText.text = damage.ToString();
        _timeText.text = time.ToString();
        _healthText.text = health.ToString();
        _titleText.TranslationName = title.name;
        _descriptionText.TranslationName = description.name;
    }
}

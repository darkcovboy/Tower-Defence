using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Lean.Localization;

public class LanguageDeterminate : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;

    
    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        ChooseLanguage(YandexGamesSdk.Environment.i18n.lang);
    }

    private void ChooseLanguage(string lang)
    {
        switch (lang)
        {
            case "en":
                _leanLocalization.SetCurrentLanguage("English");
                break;
            case "tr":
                _leanLocalization.SetCurrentLanguage("Turkish");
                break;
            case "ru":
                _leanLocalization.SetCurrentLanguage("Russian");
                break;
        }
    }
}

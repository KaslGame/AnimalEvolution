using BananaParty.WebUtility;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageSwitcher : MonoBehaviour
{
    private const string RussianLanguage = "ru";
    private const string EnglishLanguage = "en";
    private const string TurkeyLanguage = "tr";

    [SerializeField] private Button _russianButton;
    [SerializeField] private Button _englishButton;
    [SerializeField] private Button _turkeyButton;

    private string CurrentLanguage => YG2.saves.CurrentLanguage;

    private void OnEnable()
    {
        _russianButton.onClick.AddListener(SetRussianLanguage);
        _englishButton.onClick.AddListener(SetEnglishLanguage);
        _turkeyButton.onClick.AddListener(SetTurkeyLanguage);
    }

    private void OnDisable()
    {
        _russianButton.onClick.RemoveListener(SetRussianLanguage);
        _englishButton.onClick.RemoveListener(SetEnglishLanguage);
        _turkeyButton.onClick.RemoveListener(SetTurkeyLanguage);
    }

    private void SetRussianLanguage()
    {
        if (CurrentLanguage == RussianLanguage)
            return;

        YG2.SwitchLanguage(RussianLanguage);
        SetSaveLanguage(RussianLanguage);
    }

    private void SetEnglishLanguage()
    {
        if (CurrentLanguage == EnglishLanguage)
            return;

        YG2.SwitchLanguage(EnglishLanguage);
        SetSaveLanguage(EnglishLanguage);
    }

    private void SetTurkeyLanguage()
    {
        if (CurrentLanguage == TurkeyLanguage)
            return;

        YG2.SwitchLanguage(TurkeyLanguage);
        SetSaveLanguage(TurkeyLanguage);
    }

    private void SetSaveLanguage(string language)
    {
        YG2.saves.CurrentLanguage = language;
        YG2.SaveProgress();
    }
}

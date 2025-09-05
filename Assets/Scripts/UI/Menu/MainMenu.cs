using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuChanger _changer;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _settings;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(ShowShop);
        _settings.onClick.AddListener(ShowSettings);
    }   

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(ShowShop);
        _settings.onClick.RemoveListener(ShowSettings);
    }

    private void ShowShop()
    {
        _changer.SetMenu(MenuNames.Shop);
    }

    private void ShowSettings()
    {
        _changer.SetMenu(MenuNames.Settings);
    }
}

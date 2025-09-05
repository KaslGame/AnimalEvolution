using UnityEngine;
using UnityEngine.UI;
using YG;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private MenuChanger _chagner;
    [SerializeField] private SFXMenu _sfx;

    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _SFXMenuButton;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(ShowMenu);
        _SFXMenuButton.onClick.AddListener(ShowSFX);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(ShowMenu);
        _SFXMenuButton.onClick.RemoveListener(ShowSFX);
    }

    private void ShowSFX()
    {
        _sfx.Enable();
    }

    private void ShowMenu()
    {
        _chagner.SetMenu(MenuNames.MainMenu);
    }
}

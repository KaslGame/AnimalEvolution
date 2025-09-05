using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuNames _name;

    public MenuNames Name => _name;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

public enum MenuNames
{
    MainMenu,
    Shop,
    Settings
}

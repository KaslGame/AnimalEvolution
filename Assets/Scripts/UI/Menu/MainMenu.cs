using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MenuChanger _changer;
    [SerializeField] private Button _shopButton;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(ChangeMenu);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(ChangeMenu);
    }

    private void ChangeMenu()
    {
        _changer.SetMenu(MenuNames.Shop);
    }
}

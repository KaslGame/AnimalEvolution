using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MainMenuButton : MonoBehaviour
    {
        private const string Main = nameof(Main);

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ShowMain);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowMain);
        }

        private void ShowMain()
        {
            SceneManager.LoadScene(Main);
            Time.timeScale = 1f;
        }
    }
}
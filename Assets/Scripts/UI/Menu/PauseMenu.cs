using ItemScripts;
using Map;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseMenu : MonoBehaviour, IMenu
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _coin;
        [SerializeField] private SFXMenu _SFXMenu;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _menuButton;
        [SerializeField] private float _fadeDurarion;

        private CanvasGroup _group;
        private FadeAnimation _fade;
        private IPlayerStats _stats;
        private ILevelRewarder _rewarder;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();

            _fade = new FadeAnimation(_group, _fadeDurarion);
        }

        public void Initialize(IPlayerStats stats, ILevelRewarder rewarder)
        {
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _rewarder = rewarder ?? throw new ArgumentNullException(nameof(rewarder));
        }

        public void Enable()
        {
            _fade.FadeIn();

            _settings.onClick.AddListener(ShowSettings);
            _menuButton.onClick.AddListener(ShowMenu);

            _level.text = _stats.Level.ToString();
            _coin.text = _rewarder.TotalReward.ToString();
        }

        public void Disable()
        {
            _fade.FadeOut();

            _settings.onClick.RemoveListener(ShowSettings);
            _menuButton.onClick.RemoveListener(ShowMenu);
        }

        private void ShowSettings()
        {
            _SFXMenu.Enable();
        }

        private void ShowMenu()
        {
            SceneManager.LoadScene(NameScene.Main.ToString());
            Time.timeScale = 1.0f;
        }
    }
}
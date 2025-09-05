using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseMenu : MonoBehaviour, IMenu
    {
        [SerializeField] private SFXMenu _SFXMenu;
        [SerializeField] private Button _settings;
        [SerializeField] private float _fadeDurarion;
 
        private CanvasGroup _group;
        private FadeAnimation _fade;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();

            _fade = new FadeAnimation(_group, _fadeDurarion);
        }

        public void Enable()
        {
            _fade.FadeIn();
            _settings.onClick.AddListener(ShowSettings);
        }

        public void Disable()
        {
            _fade.FadeOut();
            _settings.onClick.RemoveListener(ShowSettings);
        }

        private void ShowSettings()
        {
            _SFXMenu.Enable();
        }
    }
}
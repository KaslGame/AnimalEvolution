using UnityEngine;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PauseMenu : MonoBehaviour, IMenu
    {
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
        }

        public void Disable()
        {
            _fade.FadeOut();
        }
    }
}
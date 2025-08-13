using UnityEngine;

namespace UI.Menu
{
    [RequireComponent(typeof(FadeAnimation))]
    public class PauseMenu : MonoBehaviour, IMenu
    {
        private FadeAnimation _animation;

        private void Awake()
        {
            _animation = GetComponent<FadeAnimation>();
        }

        public void Enable()
        {
            _animation.FadeIn();
        }

        public void Disable()
        {
            _animation.FadeOut();
        }
    }
}
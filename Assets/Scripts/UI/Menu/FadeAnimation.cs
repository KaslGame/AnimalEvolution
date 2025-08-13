using UnityEngine;
using DG.Tweening;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeAnimation : MonoBehaviour
    {
        private const float UnVisible = 0f;
        private const float Visible = 1f;

        [SerializeField] private float _duration = 1f;
        private CanvasGroup _group;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            _group.blocksRaycasts = false;
        }

        public void FadeOut()
        {
            _group.DOFade(UnVisible, _duration).OnComplete(Diactive);
        }

        public void FadeIn()
        {
            _group.DOFade(Visible, _duration).OnComplete(Active).SetUpdate(true);
        }

        private void Active()
        {
            _group.blocksRaycasts = true;
            _group.alpha = Visible;
        }

        private void Diactive()
        {
            _group.blocksRaycasts = false;
            _group.alpha = UnVisible;
        }
    }
}
using UnityEngine;
using System;
using DG.Tweening;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeAnimation
    {
        private const float UnVisible = 0f;
        private const float Visible = 1f;

        private float _duration = 1f;
        private CanvasGroup _group;

        public FadeAnimation(CanvasGroup group, float duration)
        {
            if (duration <= 0f)
                throw new ArgumentOutOfRangeException(nameof(duration));

            _group = group ?? throw new ArgumentNullException(nameof(group));
            _duration = duration;

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
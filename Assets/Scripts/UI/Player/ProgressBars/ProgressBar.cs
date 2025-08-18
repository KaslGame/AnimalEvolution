using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public abstract class ProgressBar : MonoBehaviour
    {
        [SerializeField] protected Image FiledImage;

        protected IPlayerStats Stats;

        public void Initialize(IPlayerStats stats)
        {
            Stats = stats;
        }

        public virtual void Start()
        {
            Stats.LevelChanged += OnLevelChanged;
            Stats.ScoreChanged += OnScoreChanged;
        }

        public virtual void OnDisable()
        {
            Stats.LevelChanged -= OnLevelChanged;
            Stats.ScoreChanged -= OnScoreChanged;
        }

        protected abstract void OnLevelChanged(int level);

        protected abstract void OnScoreChanged(float score, float needScore);
    }
}
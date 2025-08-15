using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public abstract class ProgressBar : MonoBehaviour
    {
        [SerializeField] protected Image FiledImage;

        private IPlayerStats _playerStats;

        public void Initialize(IPlayerStats stats)
        {
            _playerStats = stats;
        }

        public virtual void Start()
        {
            _playerStats.LevelChanged += OnLevelChanged;
            _playerStats.ScoreChanged += OnScoreChanged;
        }

        public virtual void OnDisable()
        {
            _playerStats.LevelChanged -= OnLevelChanged;
            _playerStats.ScoreChanged -= OnScoreChanged;
        }

        protected abstract void OnLevelChanged(int level);

        protected abstract void OnScoreChanged(float score, float needScore);
    }
}
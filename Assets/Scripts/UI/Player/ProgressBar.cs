using PlayerScripts;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Image _filedImage;
        [SerializeField] private TextMeshProUGUI _score;

        private IPlayerStats _playerStats;

        private void Awake()
        {
            _playerStats = _player.GetPlayerStats();
        }

        private void OnEnable()
        {
            _playerStats.LevelChanged += OnLevelChanged;
            _playerStats.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _playerStats.LevelChanged -= OnLevelChanged;
            _playerStats.ScoreChanged -= OnScoreChanged;
        }

        private void OnLevelChanged(int level)
        {
            _level.text = $"LV. {level}";
        }

        private void OnScoreChanged(float score, float needScore)
        {
            _score.text = $"{score}/{needScore}";
            _filedImage.fillAmount = Mathf.Clamp01(score / needScore);
        }
    }
}
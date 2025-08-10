using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Image _filedImage;
    [SerializeField] private TextMeshProUGUI _score;

    private IPlayerStats _playerStats;

    public void Initialize(IPlayerStats stats)
    {
        _playerStats = stats;
    }

    private void Start()
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
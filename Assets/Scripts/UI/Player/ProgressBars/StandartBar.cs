using TMPro;
using UnityEngine;

namespace UI.PlayerUI
{
    public class StandartBar : ProgressBar
    {
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _score;

        protected override void OnLevelChanged(int level)
        {
            _level.text = $"LV. {level}";
        }

        protected override void OnScoreChanged(float score, float needScore)
        {
            _score.text = $"{score}/{needScore}";
            FiledImage.fillAmount = Mathf.Clamp01(score / needScore);
        }
    }
}
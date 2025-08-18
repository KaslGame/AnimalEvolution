using System;

namespace PlayerScripts
{
    public class PlayerStats : IPlayerStats, IScoreChanger
    {
        private const int CostLevelScore = 50;

        private int _level = 0;
        private float _currentScore;

        public event Action<float, float> ScoreChanged;
        public event Action<int> LevelChanged;

        public int Level => _level;
        public float BasePointsPerLevel => CostLevelScore;
        public float TotalScore { get; private set; }
        private float NeedScore => _level * CostLevelScore;

        public void AddScore(float score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("Score < 0");

            _currentScore += score;
            TotalScore += score;

            TryUpdateLevel();

            ScoreChanged?.Invoke(_currentScore, NeedScore);
        }

        private void TryUpdateLevel()
        {
            if (_currentScore >= NeedScore)
            {
                _currentScore -= NeedScore;
                _level++;

                LevelChanged?.Invoke(_level);
            }
        }
    }
}

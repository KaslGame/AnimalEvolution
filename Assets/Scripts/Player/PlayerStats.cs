using System;

namespace PlayerScripts
{
    public class PlayerStats : IPlayerStats, IScoreChanger
    {
        private const int CostLevelScore = 50;

        private int _level = 1;
        private float _currentScore;

        public event Action<float, float> ScoreChanged;
        public event Action<int> LevelChanged;

        public int Level => _level;
        private float NeedScore => _level * CostLevelScore;

        public void AddScore(float score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("Score < 0");

            _currentScore += score;

            TryUpdateLevel();

            ScoreChanged?.Invoke(_currentScore, NeedScore);
        }

        private void TryUpdateLevel()
        {
            if (_currentScore >= NeedScore)
            {
                _currentScore = 0;
                _level++;

                LevelChanged?.Invoke(_level);
            }
        }
    }
}

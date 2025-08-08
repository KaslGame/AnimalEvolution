using System;

namespace PlayerScripts
{
    public class PlayerStats : IPlayerStats, ILevelChanger
    {
        private int _costLevelScore = 50;

        private int _level = 1;
        private float _currentScore;

        public event Action<float, float> ScoreChanged;
        public event Action<int> LevelChanged;

        public int Level => _level;
        private float _needScore => _level * _costLevelScore;


        public void AddScore(float score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("Score < 0");

            _currentScore += score;

            TryUpdateLevel();

            ScoreChanged?.Invoke(_currentScore, _needScore);
        }

        public void SetLevel(int level)
        {
            _currentScore = 0;
            _level = level;

            LevelChanged?.Invoke(_level);
        }

        private void TryUpdateLevel()
        {
            if (_currentScore >= _needScore)
                SetLevel(_level + 1);
        }
    }
}

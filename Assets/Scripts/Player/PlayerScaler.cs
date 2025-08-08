using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerScaler : IDisposable, IPlayerScaler
    {
        private Transform _transform;
        private IPlayerStats _playerStats;
        private float _scaleFactor;

        public PlayerScaler(Transform transform, IPlayerStats playerStats, float scaleFactor)
        {
            _transform = transform;
            _playerStats = playerStats;
            _scaleFactor = scaleFactor;

            _playerStats.LevelChanged += OnLevelChanged;
        }

        public void Reset()
        {
            _transform.localScale = Vector3.one;
        }

        public void Dispose()
        {
            _playerStats.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            _transform.localScale = new Vector3(_transform.localScale.x + _scaleFactor, _transform.localScale.y + _scaleFactor, _transform.localScale.z + _scaleFactor);
        }
    }
}
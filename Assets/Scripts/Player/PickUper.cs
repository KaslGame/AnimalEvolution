using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PickUper : MonoBehaviour, IPickUper
    {
        private PlayerStats _playerStats;

        public int Level => _playerStats.Level;

        public void Init(PlayerStats playerStats)
        {
            if (playerStats == null)
                throw new ArgumentNullException(nameof(playerStats));

            _playerStats = playerStats;
        }

        public void PickUp(float score)
        {
            _playerStats.AddScore(score);
        }
    }
}
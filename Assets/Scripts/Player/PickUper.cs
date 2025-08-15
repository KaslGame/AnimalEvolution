using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PickUper : MonoBehaviour, ICollector, IPickUper
    {
        private IScoreChanger _scoreChanger;

        public int Level => _scoreChanger.Level;

        public Transform Transform => transform;

        public void Initialize(IScoreChanger scoreChanger)
        {
            _scoreChanger = scoreChanger ?? throw new ArgumentNullException(nameof(scoreChanger));
        }

        public void PickUp(float score)
        {
            _scoreChanger.AddScore(score);
        }
    }
}
using UnityEngine;

namespace PlayerScripts
{
    public interface IScoreChanger
    {
        int Level { get; }
        void AddScore(float score);
    }
}
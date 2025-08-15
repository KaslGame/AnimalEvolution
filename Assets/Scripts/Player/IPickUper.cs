using UnityEngine;

namespace PlayerScripts
{
    public interface IPickUper
    {
        Transform Transform { get; }
        void Initialize(IScoreChanger scoreChanger);
    }

}
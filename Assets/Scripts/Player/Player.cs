using CameraScripts;
using System;
using UnityEngine;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [Header("Level Settings")]
        [SerializeField] private SoundData _sounds;
        [SerializeField] private float _scaleFactor;

        [Header("Other Settings")]
        [SerializeField] private PlayerSFX _sfx;
        [SerializeField] private CameraPursuer _pursuer;

        private IPlayerStats _stats;

        public void Initialize(IPlayerStats stats)
        {
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));

            PlayerScaler scaler = new(transform, _stats, _scaleFactor);

            _sfx.Initialize(_sounds);
            _pursuer.Initialize(transform, stats);
        }
    }
}
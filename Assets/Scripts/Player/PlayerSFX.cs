using UnityEngine;
using System;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSFX : MonoBehaviour
    {
        private IRunnable _runnable;
        private AudioSource _source;
        private SoundReproducer _reproducer;
        private SoundData _data;

        private bool _isRun;

        private void Awake()
        {
            _runnable = GetComponent<PlayerMovement>();
            _source = GetComponent<AudioSource>();

            _reproducer = new SoundReproducer(_source, _data);
        }

        public void Initialize(SoundData soundData)
        {
            _data = soundData ?? throw new ArgumentNullException(nameof(soundData));
        }

        private void OnEnable()
        {
            _runnable.RunningConditionChanged += OnRunningConditionChanged;
        }

        private void OnDisable()
        {
            _runnable.RunningConditionChanged -= OnRunningConditionChanged;
        }

        private void Update()
        {
            if (_isRun == false)
                return;

            _reproducer.Update();
            _reproducer.TryPlay();
        }

        private void OnRunningConditionChanged(bool isRun)
        {
            _isRun = isRun;
        }
    }
}
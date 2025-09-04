using System.Collections;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSFX : MonoBehaviour
    {
        private IRunnable _runnable;
        private AudioSource _source;

        private AudioClip[] _sounds;

        private bool _isRun;

        private int _currentIndex;

        private float _elapsedTime = 0f;
        private bool _soundPlaying = false;

        private void Awake()
        {
            _runnable = GetComponent<PlayerMovement>();
            _source = GetComponent<AudioSource>();
        }

        public void Initialize(StepSoundData soundData)
        {
            _sounds = soundData.Sounds;
        }

        private void OnEnable()
        {
            _runnable.RunningConditionChanged += OnRunningConditionChanged;
        }

        private void OnDisable()
        {
            _runnable.RunningConditionChanged -= OnRunningConditionChanged;
        }

        private void FixedUpdate()
        {
            if (_isRun == false)
                return;

            if (_soundPlaying)
            {
                _elapsedTime -= Time.deltaTime;

                if (_elapsedTime <= 0f)
                    _soundPlaying = false;
            }

            TryPlayStep();
        }

        private void OnRunningConditionChanged(bool isRun)
        {
            _isRun = isRun;
        }

        public void TryPlayStep()
        {
            float minPitch = 0.01f;
            float maxPitch = 1f;

            if (_soundPlaying) 
                return;

            AudioClip clip = _sounds[GetNextSoundIndex()];
            _source.clip = clip;
            _source.Play();

            float pitch = Mathf.Abs(_source.pitch) < minPitch ? maxPitch : _source.pitch;
            _elapsedTime = clip.length / pitch;
            _soundPlaying = true;
        }

        private int GetNextSoundIndex()
        {
            _currentIndex++;

            if (_currentIndex >= _sounds.Length)
                _currentIndex = 0;

            return _currentIndex;
        }
    }
}
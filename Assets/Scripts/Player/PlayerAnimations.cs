using CharacterSystem;
using System;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(FormApplier))]
    public class PlayerAnimations : MonoBehaviour
    {
        private const string Run = nameof(Run);
        private const string Eat = nameof(Eat);

        private IRunnable _runnable;
        private IFormChanger _changer;
        private IPlayerStats _stats;

        private Animator _animator;

        private void Awake()
        {
            _runnable = GetComponent<PlayerMovement>();
            _changer = GetComponent<FormApplier>();
        }

        private void OnEnable()
        {
            _runnable.RunningConditionChanged += OnRunningConditionChanged;
            _changer.FormChanged += OnFormChanged;
            _stats.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _runnable.RunningConditionChanged -= OnRunningConditionChanged;
            _changer.FormChanged -= OnFormChanged;
            _stats.ScoreChanged -= OnScoreChanged;
        }

        public void Initialize(IPlayerStats stats)
        {
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        private void OnScoreChanged(float current, float need)
        {
            if (_animator != null)
                _animator.SetTrigger(Eat);
        }

        private void OnFormChanged(Animator animator)
        {
            _animator = animator;

            if (_runnable.IsRun)
                _animator.SetBool(Run, _runnable.IsRun);
        }

        private void OnRunningConditionChanged(bool isRun)
        {
            if (_animator != null)
                _animator.SetBool(Run, isRun);
        }
    }
}
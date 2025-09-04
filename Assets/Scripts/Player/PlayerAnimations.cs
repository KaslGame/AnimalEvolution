using CharacterSystem;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(FormApplier))]
    public class PlayerAnimations : MonoBehaviour
    {
        private const string Run = nameof(Run);

        private IRunnable _runnable;
        private IFormChanger _changer;

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
        }

        private void OnDisable()
        {
            _runnable.RunningConditionChanged -= OnRunningConditionChanged;
            _changer.FormChanged += OnFormChanged;
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
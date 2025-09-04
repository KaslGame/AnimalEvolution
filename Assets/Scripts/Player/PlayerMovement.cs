using Input;
using System;
using UnityEngine;
using YG;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour, IRunnable
    {
        [SerializeField] private float _speed;

        private IInputController _inputController;
        private Rigidbody _rigidbody;

        private Vector3 _direction;

        private float _boostSpeed;

        public event Action<bool> RunningConditionChanged;

        public bool IsRun { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            SetBoostSpeed(YG2.saves.BoostSpeed);
        }

        private void Update()
        {
            if (_inputController != null)
                _direction = _inputController.GetDirection();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void SetController(IInputController inputController)
        {
            _inputController = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        private void Move()
        {
            Vector3 newVelocity = new(_direction.x, -0.1f, _direction.z);
            _rigidbody.velocity = newVelocity * (_speed + _boostSpeed);

            IsRun = CheckRun();
        }

        private void SetBoostSpeed(int levelBost)
        {
            float ratio = 2f;

            _boostSpeed = levelBost / ratio;
        }

        private bool CheckRun()
        {
            bool isRun = false;
            float normalSpeed = 1f;

            if (GetLength(_rigidbody.velocity, _rigidbody.velocity) > normalSpeed)
                isRun = true;
            else
                isRun = false;

            if (isRun != IsRun)
                RunningConditionChanged?.Invoke(isRun);

            return isRun;
        }

        private float GetLength(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
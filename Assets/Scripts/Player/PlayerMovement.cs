using Input;
using System;
using UnityEngine;
using YG;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private IInputController _inputController;
        private Rigidbody _rigidbody;

        private Vector3 _direction;

        private float _boostSpeed;

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
        }

        private void SetBoostSpeed(int levelBost)
        {
            float ratio = 2f;

            _boostSpeed = levelBost / ratio;
        }
    }
}
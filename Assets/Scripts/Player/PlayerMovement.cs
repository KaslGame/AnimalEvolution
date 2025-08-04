using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private IInputController _inputController;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _inputController = GetComponent<InputController>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.MovePosition(_rigidbody.position + _inputController.Direction * _speed * Time.fixedDeltaTime);
        }
    }
}
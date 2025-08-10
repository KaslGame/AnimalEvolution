using System;
using UnityEngine;

namespace FoodScripts
{
    public class Mover : MonoBehaviour, IMovable
    {
        private const float _stopDistance = 1f;
        private const float _speed = 10f;

        private Transform _transform;
        private Transform _target;
        private Collider _collider;
        private IEdible _food;

        public event Action<IEdible> TargetReached;

        private void Awake()
        {
            _transform = transform;
            _collider = GetComponent<Collider>();
            _food = GetComponent<IEdible>();
        }

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            Vector3 direction = _target.position - _transform.position;

            if (direction.sqrMagnitude <= _stopDistance * _stopDistance)
            {
                TargetReached?.Invoke(_food);
                return;
            }

            direction.Normalize();

            _transform.position += direction * _speed * Time.deltaTime;
        }

        public void SetTarget(Transform target)
        {
            _target = target;

            _collider.enabled = false;
        }
    }
}
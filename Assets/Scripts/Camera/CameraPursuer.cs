using UnityEngine;
using System;

namespace CameraScripts
{
    [RequireComponent(typeof(Camera))]
    public class CameraPursuer : MonoBehaviour
    {
        private const float MaxSpeed = 1f;
        private const float MinSpeed = 0.01f;
        private const float IncreaseValue = 0.5f;

        [SerializeField, Range(MinSpeed, MaxSpeed)] private float _smoothSpeed = 0.3f;
        [SerializeField] private float _tiltAngle;
        [SerializeField] private float _zOffset = -10f;
        [SerializeField] private float _height = 5f;

        private Transform _target;
        private Transform _transform;
        private IPlayerStats _stats;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _targetPosition;

        private void Awake()
        {
            _transform = transform;
            _targetPosition = _transform.position;

            _transform.rotation = Quaternion.Euler(_tiltAngle, 0f, 0f);
        }

        public void Initialize(Transform target, IPlayerStats stats)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));

            _stats.LevelChanged += OnLevelChanged;
        }

        private void OnDisable()
        {
            _stats.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            _zOffset -= IncreaseValue;
            _height += IncreaseValue;
        }

        private void LateUpdate()
        {
            if (_target == null && _targetPosition == _transform.position)
                return;

            Vector3 newPosition = _target.position;
            _targetPosition.x = newPosition.x;
            _targetPosition.y = _height;
            _targetPosition.z = newPosition.z + _zOffset;

            _transform.position = Vector3.SmoothDamp(_transform.position, _targetPosition, ref _velocity, _smoothSpeed);
        }
    }
}
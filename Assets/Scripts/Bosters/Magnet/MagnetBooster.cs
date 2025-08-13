using FoodScripts;
using Input;
using PlayerScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoostersScripts
{
    public class MagnetBooster : MonoBehaviour
    {
        [SerializeField] private TrigerZone _trigerZone;
        [SerializeField] private PickUper _pickUper;
        [SerializeField] private float _delay;

        private Vector3 _standartSize = new Vector3(5f, 2f, 5f);
        private List<IMovable> _movables = new List<IMovable>();
        private IInputController _controller;
        private WaitForSeconds _wait;
        private bool _isActive;
        private int _currnetLevel;

        public event Action<bool> TriggerStatusChanged;

        private void Awake()
        {
            _wait = new WaitForSeconds(_delay);
            ResizeZone(_currnetLevel);
        }

        private void OnEnable()
        {
            _trigerZone.FoodEntered += OnFoodEntered;
            _controller.BoosterButtonPerformed += OnButtonPerformed;
        }

        private void OnDisable()
        {
            _trigerZone.FoodEntered -= OnFoodEntered;

            if (_movables != null)
                foreach (var movable in _movables)
                    movable.TargetReached -= OnTargetReached;
        }

        public void SetLevel(int levelMagnet)
        {
            if (levelMagnet < 0)
                return;

            _currnetLevel = levelMagnet;
        }

        public void SetInputController(IInputController inputController)
        {
            _controller = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        private void OnButtonPerformed()
        {
            if (_isActive)
                return;

            EnableZone();
        }

        private void EnableZone()
        {
            _trigerZone.gameObject.SetActive(true);
            SetBoosterStatus(true);

            StartCoroutine(TimerRoutine(_wait, DisableZone));
        }

        private void DisableZone()
        {
            _trigerZone?.gameObject.SetActive(false);

            StartCoroutine(TimerRoutine(_wait, ResetBooster));
        }

        private void ResetBooster()
        {
            SetBoosterStatus(false);
        }

        private void ResizeZone(int level)
        {
            Vector3 newSize = new(_standartSize.x + level, _standartSize.y, _standartSize.z + level);
            _trigerZone.SetSizeZone(newSize);
        }

        private void SetBoosterStatus(bool boosterStatus)
        {
            _isActive = boosterStatus;
            TriggerStatusChanged?.Invoke(_isActive);
        }

        private IEnumerator TimerRoutine(WaitForSeconds wait, Action callback)
        {
            yield return wait;
            callback?.Invoke();
        }

        private void OnFoodEntered(IMovable food)
        {
            food.TargetReached += OnTargetReached;
            food.SetTarget(_pickUper.transform);

            _movables.Add(food);
        }

        private void OnTargetReached(IEdible edible)
        {
            edible.Collect(_pickUper);
        }
    }
}
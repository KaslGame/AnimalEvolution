using CharacterSystem;
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
        [SerializeField] private float _delay;

        private List<IMovable> _movables = new();
        private IInputController _controller;
        private WaitForSeconds _wait;
        private bool _isActive;

        private IContextChanger _contextChanger;
        private ICollector _collector;
        private IPickUper _pickUper;

        public event Action<bool> TriggerStatusChanged;

        private void Awake()
        {
            _wait = new WaitForSeconds(_delay);
        }

        private void OnEnable()
        {
            _trigerZone.FoodEntered += OnFoodEntered;
            _controller.BoosterButtonPerformed += OnButtonPerformed;
            _contextChanger.ContextChanged += OnContextChanged;
        }

        private void OnDisable()
        {
            _trigerZone.FoodEntered -= OnFoodEntered;
            _controller.BoosterButtonPerformed -= OnButtonPerformed;
            _contextChanger.ContextChanged -= OnContextChanged;

            if (_movables != null)
                foreach (var movable in _movables)
                    movable.TargetReached -= OnTargetReached;
        }

        public void ZoneInitialize(int levelMagnet, IPlayerStats stats)
        {
            if (levelMagnet < 0 && stats == null)
                return;

            _trigerZone.Initialize(levelMagnet, stats);
        }

        public void SetInputController(IInputController inputController)
        {
            _controller = inputController ?? throw new ArgumentNullException(nameof(inputController));
        }

        public void SetChanger(IContextChanger contextChanger)
        {
            _contextChanger = contextChanger ?? throw new ArgumentNullException(nameof(contextChanger));
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

        private void OnContextChanged(CharacterContext context)
        {
            _pickUper = context?.PickUper;
            _collector = context?.Collector;
        }

        private void OnFoodEntered(IMovable food)
        {
            food.TargetReached += OnTargetReached;
            food.SetTarget(_pickUper.Transform);

            _movables.Add(food);
        }

        private void OnTargetReached(IEdible edible)
        {
            edible.Collect(_collector);
        }
    }
}
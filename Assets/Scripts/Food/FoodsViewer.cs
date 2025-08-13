using CommonInterfaces;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FoodScripts
{
    public class FoodsViewer : IUpdateable, ISubscribable
    {
        private const float ErrorRate = 0.0001f;

        private readonly List<IFood> _foods;
        private readonly List<IFood> _foodsForClear = new List<IFood>();
        private readonly Transform _playerTransform;
        private readonly IPlayerStats _stats;
        private readonly float _drawDistanceSqr;
        private readonly int _updateEveryNFrames;

        private Vector3 _lastPosition;
        private int _frameCounter;
        private int _currentPlayerLevel;

        public FoodsViewer(List<IFood> foods, IPlayerStats stats, Transform playerTransform, float drawDistance, int updateEveryNFrames = 2)
        {
            _foods = foods ?? throw new ArgumentNullException(nameof(foods));
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _playerTransform = playerTransform ?? throw new ArgumentNullException(nameof(playerTransform));

            _drawDistanceSqr = drawDistance * drawDistance;
            _updateEveryNFrames = Mathf.Max(1, updateEveryNFrames);
        }

        private Vector3 _currentPosition => _playerTransform.position;

        public void Subscribe()
        {
            _stats.LevelChanged += OnLevelChagned;
        }

        public void Unsubscribe()
        {
            _stats.LevelChanged -= OnLevelChagned;
        }

        public void Update()
        {
            if (++_frameCounter % _updateEveryNFrames != 0)
                return;

            if ((_currentPosition - _lastPosition).sqrMagnitude < ErrorRate)
                return;

            foreach (IFood food in _foods)
            {
                if (food.IsEaten)
                {
                    food.SetActive(false);
                    _foodsForClear.Add(food);
                    continue;
                }

                Vector3 foodPosisition = food.GetPosition();
                float distanceSqr = (foodPosisition - _currentPosition).sqrMagnitude;

                if (distanceSqr <= _drawDistanceSqr)
                {
                    bool canEat = _currentPlayerLevel >= food.MinLevel;

                    food.SetActive(true);

                    SetOutline(food, canEat);

                    food.SetPassable(canEat);
                }
                else
                {
                    food.SetActive(false);
                }
            }

            CleanFoods();
        }

        private void CleanFoods()
        {
            bool isEmpty = _foodsForClear.Count <= 0;

            if (isEmpty)
                return;

            foreach (IFood food in _foodsForClear)
                _foods.Remove(food);

            _foodsForClear.Clear();
        }

        private void SetOutline(IFood food, bool canEat)
        {
            if (canEat)
                food.ActiveOutline();
            else
                food.DeactivateOutline();
        }

        private void OnLevelChagned(int level)
        {
            _currentPlayerLevel = level;
        }
    }
}
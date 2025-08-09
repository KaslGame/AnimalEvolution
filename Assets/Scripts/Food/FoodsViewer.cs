using System.Collections.Generic;
using UnityEngine;

namespace FoodScripts
{
    public class FoodsViewer : IUpdateable
    {
        private const float _errorRate = 0.0001f;

        private readonly List<IFood> _foods;
        private readonly Transform _playerTransform;
        private readonly IPlayerStats _stats;
        private readonly float _drawDistanceSqr;
        private readonly int _updateEveryNFrames;

        private Vector3 _lastPosition;
        private int _frameCounter;

        private Vector3 _currentPosition => _playerTransform.position;

        public FoodsViewer(List<IFood> foods, IPlayerStats stats, Transform playerTransform, float drawDistance, int updateEveryNFrames = 2)
        {
            _foods = foods;
            _stats = stats;
            _playerTransform = playerTransform;
            _drawDistanceSqr = drawDistance * drawDistance;
            _updateEveryNFrames = Mathf.Max(1, updateEveryNFrames);
        }

        public void Update()
        {
            if (++_frameCounter % _updateEveryNFrames != 0)
                return;

            Vector3 currentPosisiton = _currentPosition;

            if ((currentPosisiton - _lastPosition).sqrMagnitude < _errorRate)
                return;

            _lastPosition = currentPosisiton;
            int playerLevel = _stats.Level;

            foreach (IFood food in _foods)
            {
                if (food.IsEaten)
                {
                    food.SetActive(false);
                    continue;
                }

                Vector3 foodPosisition = food.GetPosition();
                float distanceSqr = (foodPosisition - currentPosisiton).sqrMagnitude;

                if (distanceSqr <= _drawDistanceSqr)
                {
                    food.SetActive(true);

                    if (playerLevel >= food.MinLevel)
                        food.ActiveOutline();
                    else
                        food.DeactivateOutline();
                }
                else
                {
                    food.SetActive(false);
                }
            }
        }
    }
}
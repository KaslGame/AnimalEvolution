using UnityEngine;
using FoodScripts;
using System.Collections.Generic;
using System.Linq;
using PlayerScripts;

namespace Bootstraps
{
    public class FoodBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _foodsObject;
        [SerializeField] private float _drawDistance;

        private IUpdateable _foodsViewer;

        private PlayerStats _playerStats;
        private Transform _playerTransform;

        private void Start()
        {
            FoodsViewerInit();
        }

        public void Initialize(PlayerStats playerStats, Transform playerTransform)
        {
            _playerStats = playerStats;
            _playerTransform = playerTransform;
        }

        public void Update()
        {
            _foodsViewer?.Update();
        }

        private void FoodsViewerInit()
        {
            List<IFood> foodList = _foodsObject.GetComponentsInChildren<IFood>().ToList();

            _foodsViewer = new FoodsViewer(foodList, _playerStats, _playerTransform, _drawDistance);
        }
    }
}
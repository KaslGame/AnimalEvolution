using UnityEngine;
using FoodScripts;
using System.Collections.Generic;
using System.Linq;
using PlayerScripts;
using CommonInterfaces;
using UI.Menu;
using System.Collections;

namespace Bootstraps
{
    public class FoodBootstrap : Bootstrap
    {
        [SerializeField] private RewardMenu _rewardMenu;
        [SerializeField] private GameObject _foodsObject;
        [SerializeField] private float _drawDistance;

        private PlayerStats _playerStats;
        private Transform _playerTransform;

        private List<ISubscribable> _subscribables = new List<ISubscribable>();
        private List<IUpdateable> _updateables = new List<IUpdateable>();

        private void OnDisable()
        {
            UnSubscribe();
        }

        public void Update()
        {
            foreach (var updateable in _updateables)
                updateable.Update();
        }

        public void Initialize(PlayerStats playerStats, Transform playerTransform)
        {
            _playerStats = playerStats;
            _playerTransform = playerTransform;
        }

        public override IEnumerator Load()
        {
            List<IFood> foodList = _foodsObject.GetComponentsInChildren<IFood>().ToList();

            FoodsViewer foodsViewer = new FoodsViewer(foodList, _playerStats, _playerTransform, _drawDistance);

            _subscribables.Add(foodsViewer);
            _updateables.Add(foodsViewer);

            _rewardMenu.SetViewer(foodsViewer);

            Subscribe();

            yield return null;
        }

        private void Subscribe()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Subscribe();
        }

        private void UnSubscribe()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Unsubscribe();
        }
    }
}
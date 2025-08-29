using CommonInterfaces;
using ItemScripts;
using Map;
using PlayerScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bootstraps
{
    public class MainBootstrap : MonoBehaviour
    {
        [SerializeField] private CoinView _coinView;
        [SerializeField] private ChoicerMap _choicerMap;
        [SerializeField] private List<MapConfig> _mapConfigs = new List<MapConfig>();

        private CoinStorage _coinStorage;
        private MapStorage _mapStorage;

        private List<ISubscribable> _subscribables = new List<ISubscribable>();

        private void Awake()
        {
            CoinsInitialize();
            MapInitialize();
        }

        private void OnEnable()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Subscribe();
        }

        private void OnDisable()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Unsubscribe();
        }

        private void CoinsInitialize()
        {
            _coinStorage = new CoinStorage();

            _coinView.Initialize(_coinStorage);
        }

        private void MapInitialize()
        {
            _mapStorage = new MapStorage(GetPaidMapsName(_mapConfigs));

            _choicerMap.Initialize(_mapConfigs, _mapStorage);
            _subscribables.Add(_mapStorage);
        }

        private List<string> GetPaidMapsName(List<MapConfig> allMap)
        {
            return allMap?.Where(map => map.PaidMap == true).Select(map => map.MapName.ToString()).ToList() ?? new List<string>();
        }
    }
}
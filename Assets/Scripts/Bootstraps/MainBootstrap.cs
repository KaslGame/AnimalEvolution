using CommonInterfaces;
using ItemScripts;
using Map;
using PlayerScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace Bootstraps
{
    public class MainBootstrap : MonoBehaviour
    {
        [SerializeField] private ShopInitializer _shopInitializer;
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

            YG2.onGetSDKData += OnLoadSDK;
        }

        private void OnDisable()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Unsubscribe();

            YG2.onGetSDKData -= OnLoadSDK;
        }

        private void OnLoadSDK()
        {
            YG2.SwitchLanguage(YG2.saves.CurrentLanguage);
        }

        private void CoinsInitialize()
        {
            _coinStorage = new CoinStorage();

            _coinView.Initialize(_coinStorage);
        }

        private void MapInitialize()
        {
            _mapStorage = new MapStorage(GetPaidMapsName(_mapConfigs));

            _shopInitializer.Initalize(_mapStorage, _coinStorage);
            _choicerMap.Initialize(_mapConfigs, _mapStorage);
            _subscribables.Add(_mapStorage);
        }

        private List<NameScene> GetPaidMapsName(List<MapConfig> allMap)
        {
            return allMap?.Where(map => map.PaidMap == true).Select(map => map.MapName).ToList() ?? new List<NameScene>();
        }
    }
}
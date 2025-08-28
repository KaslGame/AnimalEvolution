using ItemScripts;
using PlayerScripts;
using UnityEngine;

namespace Bootstraps
{
    public class MainBootstrap : MonoBehaviour
    {
        [SerializeField] private CoinView _coinView;

        private CoinStorage _coinStorage;

        private void Awake()
        {
            CoinsInitialize();
        }

        private void CoinsInitialize()
        {
            _coinStorage = new CoinStorage();

            _coinView.Initialize(_coinStorage);
        }
    }
}
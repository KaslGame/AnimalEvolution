using ItemScripts;
using TMPro;
using UnityEngine;
using System;

namespace PlayerScripts
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coin;

        private ICoinStorage _storage;

        private void Start()
        {
            _storage.CoinsChanged += OnCoinsChanged;
        }

        private void OnDisable()
        {
            _storage.CoinsChanged -= OnCoinsChanged;
        }

        public void Initialize(ICoinStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));

            _coin.text = _storage.CoinCount.ToString();
        }

        private void OnCoinsChanged(int coins)
        {
            _coin.text = coins.ToString();
        }
    }
}
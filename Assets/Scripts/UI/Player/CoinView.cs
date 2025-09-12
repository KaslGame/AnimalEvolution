using ItemScripts;
using TMPro;
using UnityEngine;
using System;

namespace PlayerScripts
{
    [RequireComponent(typeof(AudioSource))]
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coin;
        [SerializeField] private AudioClip _coindChangeSound;

        private ICoinStorage _storage;
        private AudioSource _source;

        private void Start()
        {
            _storage.CoinsChanged += OnCoinsChanged;
            _source = GetComponent<AudioSource>();
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
            _source.PlayOneShot(_coindChangeSound);
        }
    }
}
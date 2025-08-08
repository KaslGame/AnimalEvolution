using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PickUper))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _scaleFactor;

        private PickUper _pickUper;

        private PlayerStats _playerStats = new PlayerStats();
        private PlayerScaler _playerScaler;

        private void Awake()
        {
            _playerScaler = new PlayerScaler(transform, _playerStats , _scaleFactor);
            _pickUper = GetComponent<PickUper>();
            
            _pickUper.Init(_playerStats);
        }

        public IPlayerStats GetPlayerStats()
        {
            return _playerStats;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterChanger : IDisposable
    {
        private List<CharacterData> _characters;
        private IPlayerStats _stats;
        private IPlayerScaler _scaler;
        private GameObject _player;

        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        private BoxCollider _collider;

        public CharacterChanger(IPlayerStats stats, List<CharacterData> characters, GameObject playerObject, IPlayerScaler scaler)
        {
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _characters = characters ?? throw new ArgumentNullException(nameof(characters));
            _player = playerObject ?? throw new ArgumentNullException(nameof(playerObject));
            _scaler = scaler ?? throw new ArgumentNullException(nameof(scaler));

            _meshFilter = _player.GetComponent<MeshFilter>();
            _meshRenderer = _player.GetComponent<MeshRenderer>();
            _collider = _player.GetComponent<BoxCollider>();

            _stats.LevelChanged += OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            foreach (var character in _characters)
            {
                if (level >= character.MinLevel)
                {
                    ChangePlayer(character);
                    _scaler.Reset();

                    break;
                }
            }
        }

        private void ChangePlayer(CharacterData character)
        {
            _meshFilter.mesh = character.Mesh;
            _meshRenderer.material = character.Material;
            _collider.size = character.SizeCollider;

            _characters.Remove(character);
        }

        public void Dispose()
        {
            _stats.LevelChanged -= OnLevelChanged;
        }
    }
}
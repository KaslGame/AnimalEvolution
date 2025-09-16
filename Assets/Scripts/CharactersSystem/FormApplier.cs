using PlayerScripts;
using System;
using UnityEngine;

namespace CharacterSystem
{
    public class FormApplier : MonoBehaviour, IFormApplier, IFormChanger
    {
        [SerializeField] private Transform _modelTransform;

        public event Action<Animator> FormChanged;
        private GameObject _currentModel;

        public CharacterContext ApplyForm(CharacterData character)
        {
            if (_currentModel != null)
                Destroy(_currentModel);

            if (character == null || character.Prefab == null)
                return null;

            _currentModel = Instantiate(character.Prefab, _modelTransform);
            _currentModel.transform.localPosition = Vector3.zero;
            _currentModel.transform.localRotation = Quaternion.identity;

            PickUper pickUper = _currentModel.GetComponent<PickUper>();
            Animator animator = _currentModel.GetComponent<Animator>();

            FormChanged?.Invoke(animator);

            return new CharacterContext(pickUper, pickUper);
        }
    }
}

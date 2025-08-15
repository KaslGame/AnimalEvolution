using PlayerScripts;
using UnityEngine;

namespace CharacterSystem
{
    public class FormApplier : MonoBehaviour, IFormApplier
    {
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private GameObject _currentModel;
        [SerializeField] private IPickUper _pickUper;

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

            return new CharacterContext(pickUper, pickUper);
        }
    }
}

using BoostersScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerUI
{
    public class MagnetView : MonoBehaviour
    {
        [SerializeField] MagnetBooster _booster;
        [SerializeField] private Image _clockImage;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _booster.TriggerStatusChanged += OnTriggerStatusChanged;
        }

        private void OnDestroy()
        {
            _booster.TriggerStatusChanged -= OnTriggerStatusChanged;
        }

        private void OnTriggerStatusChanged(bool status)
        {
            _button.interactable = !status;
            _clockImage.gameObject.SetActive(status);
        }
    }
}

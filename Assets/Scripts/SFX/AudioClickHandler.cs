using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioClickHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _soundPlayer;
    [SerializeField] private AudioClip _sound;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }
    
    private void PlaySound()
    {
        _soundPlayer.PlayOneShot(_sound);
    }
}
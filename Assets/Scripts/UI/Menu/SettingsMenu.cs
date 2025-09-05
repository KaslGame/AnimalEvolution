using UI.Menu;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string MusicVolume = nameof(MusicVolume);

    [SerializeField] private float _fadeDurarion;

    [SerializeField] private Button _settings;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Toggle _toggleSFX;

    private CanvasGroup _group;
    private FadeAnimation _fade;

    private float _lastMasterVolume;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();

        _fade = new FadeAnimation(_group, _fadeDurarion);
    }

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _toggleSFX.onValueChanged.AddListener(ToggleMasterVolume);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _toggleSFX.onValueChanged.AddListener(ToggleMasterVolume);
    }

    public void Enable()
    {
        _settings.onClick.AddListener(HideSettings);

        _fade.FadeIn();
    }

    private void Disable()
    {
        _settings.onClick.RemoveListener(HideSettings);

        _fade.FadeOut();
    }

    private void ToggleMasterVolume(bool active)
    {
        int minValue = -80;

        if (active)
            _mixer.audioMixer.SetFloat(MasterVolume, _lastMasterVolume);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, minValue);

        SetInteractableSliders(active);
    }

    private void ChangeMasterVolume(float value)
    {
        ChangeVolume(MasterVolume, value);

        _lastMasterVolume = value;
    }

    private void ChangeMusicVolume(float value)
    {
        ChangeVolume(MusicVolume, value);
    }

    private void ChangeVolume(string name, float value)
    {
        _mixer.audioMixer.SetFloat(name, Mathf.Lerp(-80, 0, value));
    }

    private void SetInteractableSliders(bool state)
    {
        _masterSlider.interactable = state;
        _musicSlider.interactable = state;
    }

    private void HideSettings()
    {
        Disable();
    }
}

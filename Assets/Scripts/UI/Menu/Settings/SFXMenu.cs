using System;
using UI.Menu;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

public class SFXMenu : MonoBehaviour
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
        YG2.onDefaultSaves += OnResetSaves;
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _toggleSFX.onValueChanged.AddListener(ToggleMasterVolume);
        YG2.onDefaultSaves -= OnResetSaves;
    }

    private void Start()
    {
        LoadSaveVolume();
    }

    public void Enable()
    {
        _settings.onClick.AddListener(HideSettings);

        LoadSaveVolume();
        _fade.FadeIn();
    }

    private void LoadSaveVolume()
    {
        float masterVolume = YG2.saves.MasterVolume;
        float musicVolume = YG2.saves.MusicVolume;
        bool isMute = YG2.saves.IsMute;

        if (YG2.isSDKEnabled == false)
            return;

        _lastMasterVolume = masterVolume;
        _masterSlider.value = masterVolume;
        _musicSlider.value = musicVolume;
        _toggleSFX.isOn = isMute;

        ChangeMusicVolume(musicVolume);

        if (isMute == false)
            ToggleMasterVolume(isMute);
        else
            ChangeMasterVolume(masterVolume);
    }

    private void OnResetSaves()
    {
        float maxVolume = 1f;

        ChangeMusicVolume(maxVolume);
        ChangeMasterVolume(maxVolume);
        ToggleMasterVolume(true);
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

        YG2.saves.IsMute = active;
    }

    private void ChangeMasterVolume(float value)
    {
        ChangeVolume(MasterVolume, value);

        _lastMasterVolume = value;

        YG2.saves.MasterVolume = value;
    }

    private void ChangeMusicVolume(float value)
    {
        ChangeVolume(MusicVolume, value);

        YG2.saves.MusicVolume = value;
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

        YG2.SaveProgress();
    }
}

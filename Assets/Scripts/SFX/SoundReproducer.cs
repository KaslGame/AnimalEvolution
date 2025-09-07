using UnityEngine;
using System;

public class SoundReproducer : IUpdateable
{
    private readonly AudioSource _source;
    private readonly Viewer<AudioClip> _viewer;

    private float _elapsedTime;
    private bool _isPlaying;

    public SoundReproducer(AudioSource audioSource, SoundData data)
    {
        _source = audioSource ?? throw new ArgumentNullException(nameof(audioSource));

        if (data == null)
            throw new ArgumentNullException(nameof(data));

        _viewer = new Viewer<AudioClip>(data.Sounds);
    }

    public void Update()
    {
        if (_isPlaying == false)
            return;

        _elapsedTime -= Time.deltaTime;

        if (_elapsedTime <= 0f)
            _isPlaying = false;
    }

    public void TryPlay()
    {
        float minPitch = 0.01f;
        float maxPitch = 1f;

        if (_isPlaying)
            return;

        AudioClip clip = _viewer.GetNextItem();
        _source.clip = clip;
        _source.Play();

        float pitch = Mathf.Abs(_source.pitch) < minPitch ? maxPitch : _source.pitch;
        _elapsedTime = clip.length / pitch;
        _isPlaying = true;
    }
}

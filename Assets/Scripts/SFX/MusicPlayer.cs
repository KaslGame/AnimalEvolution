using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private SoundData _musicData;

    private AudioSource _audioSource;
    private SoundReproducer _reproducer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _reproducer = new SoundReproducer(_audioSource, _musicData);
    }

    private void Update()
    {
        _reproducer.Update();
        _reproducer.TryPlay();
    }
}

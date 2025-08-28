using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    private AudioSource _audioSource;

    [SerializeField] private SoundData soundData;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        Instance = this;
    }

    public void PlaySound(int soundId)
    {
        _audioSource.PlayOneShot(soundData.audioClips[soundId]);
    }
}

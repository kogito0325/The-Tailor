using UnityEngine;

public enum VolumeType
{
    BGM,
    SFX
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _audioSourceBGM;
    [SerializeField] private AudioSource _audioSourceSFX;

    [SerializeField] private SoundData soundData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        SetVolumeBGM(PlayerPrefs.GetFloat(VolumeType.BGM.ToString(), _audioSourceBGM.volume));
        SetVolumeSFX(PlayerPrefs.GetFloat(VolumeType.SFX.ToString(), _audioSourceSFX.volume));

        PlayerPrefs.SetFloat(VolumeType.BGM.ToString(), _audioSourceBGM.volume);
        PlayerPrefs.SetFloat(VolumeType.SFX.ToString(), _audioSourceSFX.volume);
    }

    public void PlaySound(int soundId)
    {
        _audioSourceSFX.PlayOneShot(soundData.audioClips[soundId]);
    }

    public void SetVolumeBGM(float vol)
    {
        _audioSourceBGM.volume = vol;
        PlayerPrefs.SetFloat(VolumeType.BGM.ToString(), vol);
    }

    public void SetVolumeSFX(float vol)
    {
        _audioSourceSFX.volume = vol;
        PlayerPrefs.SetFloat(VolumeType.SFX.ToString(), vol);
    }

    public float GetVolume(VolumeType volumeType)
    {
        return volumeType == VolumeType.BGM ? _audioSourceBGM.volume : volumeType == VolumeType.SFX ? _audioSourceSFX.volume : float.NaN;
    }
}

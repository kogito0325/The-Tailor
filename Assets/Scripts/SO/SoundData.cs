using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundData", menuName = "Scriptable Objects/SoundData")]
public class SoundData : ScriptableObject
{
    public AudioClip[] audioClips;
}

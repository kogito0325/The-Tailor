using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    public enum Sound
    {
        MonsterSpawn,
        MonsterHit,
        PlayerSlide,
        PlayerLand,
        PlayerJump,
        PlayerAttack,
        PlayerDead,
        PlayerHit
    }

    public void PlaySound(Sound sound)
    {
        SoundManager.Instance.PlaySound((int)sound);
    }
}


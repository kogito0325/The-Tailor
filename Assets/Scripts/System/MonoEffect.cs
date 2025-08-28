using UnityEngine;

public class MonoEffect : MonoBehaviour
{
    public enum Type
    {
        MonsterHit,
        MonsterSpawn,
        PlayerHit,
        PlayerDead
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class MonoEffect : MonoBehaviour
{
    public enum Type
    {
        MonsterHit,
        MonsterSpawn,
        PlayerHit,
        PlayerDead,
        BossDead0,
        BossDead1,
        BossDead2
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

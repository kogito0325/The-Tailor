using UnityEngine;

public class EffectHelper : MonoBehaviour
{
    public void PlayEffect(MonoEffect.Type type)
    {
        EffectManager.Instance.PlayEffect(transform, (int)type);
    }

    public void PlayEffect(Transform transform, MonoEffect.Type type)
    {
        EffectManager.Instance.PlayEffect(transform, (int)type);
    }

    public void PlayMonsterSpawnEffect(string objectName)
    {
        EffectManager.Instance.PlayEffect(GameObject.Find(objectName).transform, (int)MonoEffect.Type.MonsterSpawn);
    }
}


using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;


    [SerializeField] private EffectData effectData;

    void Start()
    {
        Instance = this;
    }

    public void PlayEffect(Transform transform, int effectId)
    {
        Instantiate(effectData.effects[effectId], transform.position, Quaternion.identity);
    }
}

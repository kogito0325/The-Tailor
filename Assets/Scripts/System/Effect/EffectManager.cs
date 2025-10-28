using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;


    [SerializeField] private EffectData effectData;

    void Start()
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
    }

    public void PlayEffect(Transform transform, int effectId)
    {
        Instantiate(effectData.effects[effectId], transform.position, Quaternion.identity);
    }

    public void PlayEffect(Vector2 position, int effectId)
    {
        Instantiate(effectData.effects[effectId], position, Quaternion.identity);
    }
}

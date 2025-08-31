using UnityEngine;

public class EndingProductionManager : MonoBehaviour
{
    [SerializeField] private Vector2 startPoint;
    [SerializeField] private Vector2 endPoint;

    public static EndingProductionManager Instance;

    private void Start()
    {
        Instance = this;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint, new Vector2(endPoint.x, startPoint.y));
        Gizmos.DrawLine(new Vector2(endPoint.x, startPoint.y), endPoint);
        Gizmos.DrawLine(endPoint, new Vector2(startPoint.x, endPoint.y));
        Gizmos.DrawLine(new Vector2(startPoint.x, endPoint.y), startPoint);
    }

    public void FireRandomEffect()
    {
        if (Random.Range(0, 2) == 1)
        {
            FireEffect(MonoEffect.Type.BossDead0);
        }
        else
        {
            FireEffect(MonoEffect.Type.BossDead1);
        }
    }

    public void FireEffect(MonoEffect.Type type)
    {
        EffectManager.Instance.PlayEffect(ChooseRandomPoint(), (int)type);
        SoundManager.Instance.PlaySound((int)SoundHelper.Sound.PlayerHit);
    }

    public void DeActiveBoss()
    {
        FindAnyObjectByType<MonoBoss>().gameObject.SetActive(false);
    }

    private Vector2 ChooseRandomPoint()
    {
        return new Vector2(Random.Range(startPoint.x, endPoint.x), Random.Range(startPoint.y, endPoint.y));
    }
}

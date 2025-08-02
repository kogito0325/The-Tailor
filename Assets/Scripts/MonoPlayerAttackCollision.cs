using UnityEngine;

public class MonoPlayerAttackCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.TryGetComponent(out IHittable hittable))
        {
            hittable.Hit(1);
        }
    }
}

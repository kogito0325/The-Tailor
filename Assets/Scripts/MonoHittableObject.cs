using UnityEngine;

public abstract class MonoHittableObject : MonoBehaviour, IHittable
{
    protected Collider2D _collider2D;

    protected virtual void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public abstract void Hit(int damage);
}

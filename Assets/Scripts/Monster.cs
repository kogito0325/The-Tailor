using UnityEngine;

public class Monster : MonoHittableObject
{
    protected Rigidbody2D _rigidbody2D;

    private bool _isDead;
    
    [SerializeField] protected float speed;
    
    [SerializeField] private float flyPower;
    [SerializeField] private float flyTime;

    protected override void Start()
    {
        base.Start();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _isDead = false;
    }

    public override void Hit(int damage = 1)
    {
        _isDead = true;
        _rigidbody2D.AddForce((Vector2.right + Vector2.up).normalized * flyPower, ForceMode2D.Impulse);

        // 임시 코드
        GetComponent<Animator>().Play("Fly");
        Destroy(gameObject, flyTime);
    }

    private void Move()
    {
        _rigidbody2D.linearVelocityX = -speed;
    }


    protected virtual void Update()
    {
        if (!_isDead)
            Move();
    }
}

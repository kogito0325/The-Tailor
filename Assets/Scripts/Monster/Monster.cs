using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoHittableObject
{
    protected Rigidbody2D _rigidbody2D;

    private bool _isDead;
    private float _hp;

    [SerializeField] private MonsterData monsterData;

    protected float _speed;
    
    [SerializeField] private float flyPower;
    [SerializeField] private float flyTime;

    protected override void Start()
    {
        base.Start();
        _hp = monsterData.hp;
        _speed = monsterData.speed;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _isDead = false;
    }

    public override void Hit(int damage = 1)
    {
        Die();
        _rigidbody2D.linearVelocity = Vector3.zero;
        _rigidbody2D.AddForce((Vector2.right + Vector2.up).normalized * flyPower, ForceMode2D.Impulse);

        // 임시 코드
        GetComponent<Animator>().Play("Fly");
        SoundManager.Instance.PlaySound((int)SoundHelper.Sound.MonsterHit);
        EffectManager.Instance.PlayEffect(transform, (int)MonoEffect.Type.MonsterHit);
        Destroy(gameObject, flyTime);
    }

    private void Move()
    {
        _rigidbody2D.linearVelocityX = -_speed;
    }

    private void Die()
    {
        _isDead = true;
        _collider2D.enabled = false;
        FindAnyObjectByType<MonoBoss>().TakeDamage(1);
    }


    protected virtual void Update()
    {
        if (!_isDead)
            Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MonoPlayer player))
        {
            player.Hit();
            GetComponent<Collider2D>().enabled = false;
            _rigidbody2D.linearVelocityY = 0;
        }
    }
}

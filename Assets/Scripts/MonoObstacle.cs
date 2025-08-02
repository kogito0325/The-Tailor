using UnityEngine;

public class MonoObstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.linearVelocityX = -speed;
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

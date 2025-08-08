using UnityEngine;

public class MonoObstacle : MonoBehaviour
{
    [SerializeField] private ObstacleData obstacleData;

    private float _speed;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _speed = obstacleData.speed;

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.linearVelocityX = -_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MonoPlayer player) && player.Hp > 0)
        {
            player.Hit();
            GetComponent<Collider2D>().enabled = false;
            _rigidbody2D.linearVelocityY = 0;
        }
    }
}

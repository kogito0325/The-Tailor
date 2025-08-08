using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MonoPlayer : MonoBehaviour, IHittable
{
    private PlayerAnimController _animController;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private MonoPlayerAttackCollision attackColider;

    private bool _isGrounded;
    private bool _isSliding;

    public int Hp { get; private set; }

    [field: SerializeField] public PlayerData PlayerData { get; private set; }

    private void Start()
    {
        _isGrounded = true;
        _isSliding = false;
        _animController = new PlayerAnimController(GetComponent<Animator>());
        _animController.SetAnimState(PlayerAnimState.Run);

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.linearDamping = PlayerData.linearDamping;
        _rigidbody2D.gravityScale = PlayerData.gravityScale;
        Hp = PlayerData.hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isSliding = false;
            _isGrounded = false;
            _rigidbody2D.AddForceY(PlayerData.jumpPower, ForceMode2D.Impulse);
            _animController.SetAnimState(PlayerAnimState.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        else if (Input.GetKey(KeyCode.D) && _isGrounded && !_isSliding)
        {
            _isSliding = true;
            _animController.SetAnimState(PlayerAnimState.Slide);
        }
        else if (Input.GetKeyUp(KeyCode.D) && _isSliding)
        {
            _isSliding = false;
            _animController.SetAnimState((PlayerAnimState.Run));
        }
    }

    public void Hit(int damage = 1)
    {
        TakeDamage(damage);
    }

    private void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0) Die();
        else StartCoroutine(Evasion());
    }

    private void Attack()
    {
        _animController.SetAnimState(PlayerAnimState.Attack);
    }

    private void Die()
    {
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Evasion");
        _animController.SetAnimState(PlayerAnimState.Die);
    }

    private IEnumerator Evasion()
    {
        gameObject.layer = LayerMask.NameToLayer("Evasion");
        GetComponent<SpriteRenderer>().color = Color.gray;
        yield return new WaitForSeconds(PlayerData.evasionTime);
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_isGrounded && Hp > 0)
        {
            _isGrounded = true;
            _animController.SetAnimState(PlayerAnimState.Run);
        }
    }
}

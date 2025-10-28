using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class MonoPlayer : MonoBehaviour, IHittable
{
    private PlayerAnimController _animController;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private MonoPlayerAttackCollision attackColider;
    //[SerializeField] private Material flashMat;
    //private Material originMat;
    //private Material curMat;

    private bool _isGrounded;
    private bool _isSliding;
    private bool _isInEvasion => gameObject.layer == LayerMask.NameToLayer("Evasion");

    public int Hp { get; private set; }

    private float _attackCoolTimer;

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
        _attackCoolTimer = 0;

        //originMat = GetComponent<MeshRenderer>().material;
    }

    

    private void Update()
    {

        // KeyManager에서 설정된 키를 가져와 사용합니다.
        KeyCode jumpKey = KeyManager.instance.Keys[PlayerActionType.Jump];
        KeyCode attackKey = KeyManager.instance.Keys[PlayerActionType.Attack];
        KeyCode slideKey = KeyManager.instance.Keys[PlayerActionType.Slide];

        if (Input.GetKeyDown(jumpKey) && _isGrounded)
        {
            _isSliding = false;
            _isGrounded = false;
            _rigidbody2D.AddForceY(PlayerData.jumpPower, ForceMode2D.Impulse);
            _animController.SetAnimState(PlayerAnimState.Jump);
        }
        else if (Input.GetKeyDown(attackKey))
        {
            if (_attackCoolTimer <= 0)
                Attack();
        }
        else if (Input.GetKey(slideKey) && _isGrounded && !_isSliding)
        {
            _isSliding = true;
            _animController.SetAnimState(PlayerAnimState.Slide);
            SoundManager.Instance.PlaySound((int)SoundHelper.Sound.PlayerSlide);
        }
        else if (Input.GetKeyUp(slideKey) && _isSliding)
        {
            _isSliding = false;
            _animController.SetAnimState(PlayerAnimState.Run);
        }

        if(_attackCoolTimer > 0)
            _attackCoolTimer -= Time.deltaTime;

        if (GameManager.Instance.CurrentGameMode == GameMode.Challenge && Hp > 0)
            FindAnyObjectByType<ChallengeManager>().AddScore(PlayerData.scorePerSec * Time.deltaTime);
    }

    public void Hit(int damage = 1)
    {
        TakeDamage(damage);
        SoundManager.Instance.PlaySound((int)SoundHelper.Sound.PlayerHit);
        EffectManager.Instance.PlayEffect(new Vector2(transform.position.x, transform.position.y + 2f), (int)MonoEffect.Type.PlayerHit);
    }

    public void TakeDamage(int damage)
    {
        if (_isInEvasion) return;
        Hp -= damage;
        if (Hp <= 0) Die();
        else StartCoroutine(Evasion());
    }

    private void Attack()
    {
        _attackCoolTimer = PlayerData.attakCool;
        _animController.SetAnimState(PlayerAnimState.Attack);
    }

    public void ActivateAttackRange()
    {
        attackColider.ActivateAttackRange(true);
    }

    public void DeActivateAttackRange()
    {
        attackColider.ActivateAttackRange(false);
    }

    private void Die()
    {
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Evasion");
        _animController.SetAnimState(PlayerAnimState.Die);
        _rigidbody2D.linearDamping = 0;
        _rigidbody2D.angularDamping = 0;
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        _rigidbody2D.AddForce((Vector2.up * 2f + Vector2.left) * 5f, ForceMode2D.Impulse);
        _rigidbody2D.AddTorque(180f);

        SoundManager.Instance.PlaySound((int)SoundHelper.Sound.PlayerDead);
        EffectManager.Instance.PlayEffect(transform, (int)MonoEffect.Type.PlayerDead);

        FindAnyObjectByType<ChallengeManager>().EndProcess();
    }

    private IEnumerator Evasion()
    {
        gameObject.layer = LayerMask.NameToLayer("Evasion");
        //GetComponent<SpriteRenderer>().color = Color.gray;
        //GetComponent<MeshRenderer>().material = flashMat;
        yield return new WaitForSeconds(PlayerData.evasionTime);
        gameObject.layer = LayerMask.NameToLayer("Default");
        //GetComponent<SpriteRenderer>().color = Color.white;
        //GetComponent<MeshRenderer>().material = originMat;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_isGrounded && Hp > 0)
        {
            _rigidbody2D.linearVelocityY = 0;
            _isGrounded = true;
            _animController.SetAnimState(PlayerAnimState.Run);
            SoundManager.Instance.PlaySound((int)SoundHelper.Sound.PlayerLand);
        }
    }
}

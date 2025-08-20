using UnityEngine;

public class AttackableMonster : Monster
{
    private MonoPlayer _player;
    private Animator _animator;

    private bool _isAttacked;

    protected override void Start()
    {
        base.Start();
        _player = FindAnyObjectByType<MonoPlayer>();
        _animator = GetComponent<Animator>();
        _isAttacked = false;
    }

    protected override void Update()
    {
        base.Update();
        if (CheckPlayerPosition(_player.transform, out float isUpWard) && !_isAttacked)
        {
            Attack(_player, isUpWard, 1);
            _isAttacked = true;
        }
    }

    private bool CheckPlayerPosition(Transform playerTransform, out float playerPosY)
    {
        playerPosY = playerTransform.position.y >= transform.position.y ? 1 : -1;
        return playerTransform.position.x >= transform.position.x;
    }

    private void Attack(MonoPlayer player, float attackDir, int damage)
    {
        player.TakeDamage(damage);
        _animator.SetFloat("playerPosY", attackDir);
        _animator.Play("Attack");
    }
}

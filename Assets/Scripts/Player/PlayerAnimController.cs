using UnityEngine;

public enum PlayerAnimState
{
    Idle,
    Run,
    Jump,
    Attack,
    Slide,
    Die
}

public class PlayerAnimController
{
    private Animator _animator;

    public PlayerAnimController(Animator animator)
    {
        _animator = animator;
    }
    
    public void SetAnimState(PlayerAnimState animState)
    {
        _animator.SetTrigger(animState.ToString());
    }
}

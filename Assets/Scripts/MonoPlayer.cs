using System.Runtime.CompilerServices;
using UnityEngine;

public class MonoPlayer : MonoBehaviour
{
    PlayerAnimController animController;
    Rigidbody2D rigid;

    private bool isGrounded;
    private bool isSliding;
    [SerializeField] private float jumpPower;

    private void Start()
    {
        isGrounded = true;
        isSliding = false;
        animController = new PlayerAnimController(GetComponent<Animator>());
        animController.SetAnimState(PlayerAnimState.Run);

        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isSliding = false;
            isGrounded = false;
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);
            animController.SetAnimState(PlayerAnimState.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animController.SetAnimState(PlayerAnimState.Attack);
        }
        else if (Input.GetKey(KeyCode.D) && isGrounded && !isSliding)
        {
            isSliding = true;
            animController.SetAnimState(PlayerAnimState.Slide);
        }
        else if (Input.GetKeyUp(KeyCode.D) && isSliding)
        {
            isSliding = false;
            animController.SetAnimState((PlayerAnimState.Run));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
            animController.SetAnimState(PlayerAnimState.Run);
        }
    }
}

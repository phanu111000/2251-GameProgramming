using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float moving;
    [SerializeField] private float jumping;

    [SerializeField] private Transform groundPoint;
    [SerializeField] private bool isOnGround;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator anim;
    [SerializeField] private bool canJump;
    [SerializeField] private Transform playerTransform;
  
    private float movingInput;

    private void Update()
    {
        Flip();

        GroundCheck();
        CheckCanJump();
        PlayerAnimation();
    }
        
    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        movingInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (canJump)
        {
            if (value.isPressed)
            {
                rb.AddForce(jumping * transform.up, ForceMode2D.Impulse);
            }   
        }
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(movingInput * moving, rb.velocity.y);
    }

    private void Flip()
    {
        if (movingInput == -1)
        {
            playerTransform.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (movingInput == 1)
        {
            playerTransform.transform.localScale = Vector3.one;
        }
    }   

    private void GroundCheck()
    {
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    private void CheckCanJump()
    {
        if(isOnGround)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void PlayerAnimation()
    {
        anim.SetBool("IsOnGround", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

}
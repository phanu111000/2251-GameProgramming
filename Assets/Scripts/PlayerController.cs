using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float moving;
    [SerializeField] private float jumping;
    private float movingInput;


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movingInput * moving, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        movingInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(jumping * transform.up, ForceMode2D.Impulse);
        }
    }

}
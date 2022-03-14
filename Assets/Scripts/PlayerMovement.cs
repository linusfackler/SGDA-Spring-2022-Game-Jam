using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private float horizontal;       // moving direction on x-axis
    public float speed;             // unique stat - running speed
    public float jumpingPower;      // unique stat - jumping speed
    private bool hasDoubleJumped;   // controls whether double jump used
    private bool isFacingRight = true;

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
            Flip();         // flip if character moves in opposite direction
        else if (isFacingRight && horizontal < 0f)
            Flip();         // flip if character moves in opposite direction

        if (Mathf.Abs(rb.velocity.y) == 0)
        {
            hasDoubleJumped = false;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJump", false);
            animator.SetBool("IsFalling", false);
            // number of jumps reset, animation reset
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        // set speed variable for animations
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (hasDoubleJumped)
            {
                return;
            }

            if (rb.velocity.y == 0)
            {
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            else
            {
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);        
                hasDoubleJumped = true; 
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsDoubleJump", true);
            }
        }


        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.7f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Land(InputAction.CallbackContext context)
    {
        if (!isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed*0.8f);
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsDoubleJump", false);
            animator.SetBool("IsJumping", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private float horizontal;
    public float speed;             // unique stat - running speed
    public float jumpingPower;      // unique stat - jumping speed
    private int numJumps;           // number of jumps
    private bool isFacingRight = true;

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();         // flip if character moves in opposite direction
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();         // flip if character moves in opposite direction
        }

        if (Mathf.Abs(rb.velocity.y) == 0)
        {
            numJumps = 2;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJump", false);
            animator.SetBool("IsFalling", false);
            // number of jumps reset, animation reset
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && numJumps > 0)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (numJumps <= 1)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJump", true);
            Debug.Log("REACHED DOUBLE JUMP");
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            numJumps--;
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

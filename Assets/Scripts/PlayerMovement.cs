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
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;
    private int numJumps;

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if (isGrounded())
        {
            numJumps = 2;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJump", false);
            animator.SetBool("IsFalling", false);
        }

        if (rb.velocity.y == 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));            
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            numJumps--;
        }

        if (context.performed && numJumps > 0)
        {
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            Debug.Log("NumJumps: " + numJumps);


            if (numJumps == 0)
            {
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

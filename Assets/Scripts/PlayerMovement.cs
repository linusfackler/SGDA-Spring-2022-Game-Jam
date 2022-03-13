using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

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
            numJumps = 1;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && numJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            numJumps--;
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

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    //public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Vector2 startPos;

    private float horizontal;       // moving direction on x-axis
    public float speed;             // unique stat - running speed
    public float jumpingPower;      // unique stat - jumping speed
    private bool hasDoubleJumped;   // controls whether double jump used
    public bool isFacingRight = true;

    private float oldHeight;

    private Vector3 groundPos;

    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
            Flip();         // flip if character moves in opposite direction
        else if (isFacingRight && horizontal < 0f)
            Flip();         // flip if character moves in opposite direction


        if (Mathf.Abs(rb.velocity.y) == 0f)
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

            else if (rb.velocity.y == 0)
            {
                oldHeight = rb.position.y;
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            else
            {
                oldHeight = rb.position.y;
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);        
                hasDoubleJumped = true; 
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsDoubleJump", true);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Land(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed * 1.6f);
                animator.SetBool("IsFalling", true);
                animator.SetBool("IsDoubleJump", false);
                animator.SetBool("IsJumping", false);
            }

            if (Mathf.Abs(rb.velocity.y) == 0f)
            {
                animator.SetBool("IsFalling", false);            
            }
        }
    }

    private bool isGrounded()
    {
        groundPos = new Vector3 (transform.position.x, transform.position.y - this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y, transform.position.z);
        return Physics2D.OverlapCircle(groundPos, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}

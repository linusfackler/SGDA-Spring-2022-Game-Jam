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
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

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
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("wants to jump");
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }




    // PlayerControls controls;
    // private Rigidbody2D body;

    // Vector2 move;

    // [SerializeField] public float speed;

    // private float fallingspeed = -2.5f;

    // void Awake()
    // {
    //     body = GetComponent<Rigidbody2D>();

    //     controls = new PlayerControls();

    //     // controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //     // controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

    //     controls.Gameplay.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());

    //     controls.Gameplay.Jump.performed += ctx => Jump();
    // }

    // void Update()
    // {
    //     // Vector2 m = new Vector2(move.x, move.y) * speed * Time.deltaTime;

    //     transform.Translate(move, Space.World);

    // }

    // void Move(Vector2 direction)
    // {
    //     if (!body.IsTouchingLayers())
    //     {
    //         move = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;            
    //     }

    //     else
    //     {
    //         move = new Vector2(direction.x, 0) * speed * Time.deltaTime;
    //     }
    // }

    // void Jump()
    // {
    //     if (body.IsTouchingLayers())
    //     {
    //         move = new Vector2(move.x, 1) * speed * Time.deltaTime;            
    //     }
    // }

    // void OnEnable()
    // {
    //     controls.Gameplay.Enable();
    // }

    // void OnDisable()
    // {
    //     controls.Gameplay.Disable();
    // }

}

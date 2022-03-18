using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    private Vector2 currentPosition;
    public float speed;
    public Rigidbody2D rb;

    public int playerID;
    public Vector2 startPos;

    void Start()
    {
        transform.position = startPos;
    }

    private void FixedUpdate()
    {
        // if (rb.position.x > 20f && rb.position.x < 820f && rb.position.y > 10f && rb.position.y < 445f)
        // {
        //     rb.velocity = currentPosition * speed;
        // }
        rb.velocity = currentPosition * speed;
        // else
        // {
        //     if (rb.position.x < 20f)
        //         rb.position.Set(30f, rb.position.y);
        //     else if (rb.position.x > 820f)
        //         rb.position.Set(810f, rb.position.y);
        //     else if (rb.position.y < 10f)
        //         rb.position.Set(rb.position.x, 20f);
        //     else
        //         rb.position.Set(rb.position.x, 435f);
        // }

    }

    public void Move(InputAction.CallbackContext context)
    {
        currentPosition = context.ReadValue<Vector2>();
    }
}

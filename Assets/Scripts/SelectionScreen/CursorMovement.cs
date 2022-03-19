using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    private Vector2 currentPosition;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 startPos;

    void Start()
    {
        transform.position = startPos;
    }

    private void FixedUpdate()
    {
        rb.velocity = currentPosition * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        currentPosition = context.ReadValue<Vector2>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
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
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}

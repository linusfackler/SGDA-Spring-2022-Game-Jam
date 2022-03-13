using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // private Rigidbody2D body;

    Vector2 move;

    PlayerControls controls;

    [SerializeField] public float speed;

    void Awake()
    {
        // body = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Jump.performed += ctx => Jump();

    }

    void Jump()
    {
        Debug.Log("Wants to jump!");
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, 0) * speed * Time.deltaTime;
        transform.Translate(m, Space.World);


    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}

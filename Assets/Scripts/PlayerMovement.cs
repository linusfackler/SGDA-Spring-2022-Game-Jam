using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private load Awake()
    {
        body = GetComponent<Rigidbody2D>;
    }
}

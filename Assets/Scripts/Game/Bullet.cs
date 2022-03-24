using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public PlayerInput player;

    void Start()
    {

        rb.velocity = transform.right * speed;
        //print("playerID: " + playerID);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if(hitInfo.TryGetComponent<PlayerInput>(out var playerInput))
        {
            if(player == playerInput)
                return;

            
        }


        Destroy(gameObject);
    }

    void kill(PlayerInput hitPlayer)
    {

    }
}

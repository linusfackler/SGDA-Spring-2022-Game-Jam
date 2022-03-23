using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //public static int playerID;

    void Start()
    {

        rb.velocity = transform.right * speed;
        //print("playerID: " + playerID);
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Destroy(gameObject);
    }
    // more code to follow

}

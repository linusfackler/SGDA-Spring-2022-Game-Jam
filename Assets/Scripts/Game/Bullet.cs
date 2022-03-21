using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            print("Landed in 1");
            rb.velocity = transform.right * speed;
        }

        else
        {
            print("landed in 2");
            rb.velocity = transform.right * -speed;
        }

    }

    // void OnTriggerEnter2D (Collider2D hitInfo)
    // {
    //     Destroy(gameObject);
    //     Debug.Log(hitInfo.name);
    // }

}

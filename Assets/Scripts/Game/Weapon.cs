using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private AudioSource shootAudio;
    public AudioClip[] shootSound;
    //private int id;
    private int character;

    public GameObject[] bullet;

    private GameObject firepoint;
    private Vector3 rot;


    public void Start()
    {
        if (this.gameObject.name == "Player0")
        {
            //id = 0;
            character = CursorDetection.pickedPlayer0;
            firepoint = SpawnPlayer.firePoint0;
        }

        else
        {
            //id = 1;
            character = CursorDetection.pickedPlayer1;
            firepoint = SpawnPlayer.firePoint1;
        }
        shootAudio = GetComponent<AudioSource>();
        
        
        //character = SpawnPlayer.character;
        shootAudio.clip = shootSound[character];
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {  
            if (this.gameObject.name == "Player0")
            {
                Instantiate(bullet[character], firepoint.transform.position, firepoint.transform.rotation);     
            }

            else
            {
                firepoint.transform.Rotate(0f, 180f, 0f);
                Instantiate(bullet[character], firepoint.transform.position, firepoint.transform.rotation);  
            }
                
                shootAudio.Play();

        }

    }
}

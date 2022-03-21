using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private AudioSource shootAudio;
    public AudioClip[] shootSound;
    //private int id;
    private int character;

    public GameObject[] bullet;

    private Transform firepoint;


    public void Start()
    {
        if (this.gameObject.name == "Player0")
        {
            //id = 0;
            character = CursorDetection.pickedPlayer0;
            firepoint = SpawnPlayer.firePoint0.transform;
        }

        else
        {
            //id = 1;
            character = CursorDetection.pickedPlayer1;
            firepoint = SpawnPlayer.firePoint1.transform;
        }
        shootAudio = GetComponent<AudioSource>();
        
        
        //character = SpawnPlayer.character;
        shootAudio.clip = shootSound[character];
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {  
            Instantiate(bullet[character], firepoint.position, firepoint.rotation);
            shootAudio.Play();

        }

    }
}

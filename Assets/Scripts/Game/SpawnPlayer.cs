using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class SpawnPlayer : MonoBehaviour
{
    public Transform[] spawnLocations;
    public PlayerInputManager playerManager;
    public SpriteLibraryAsset[] sla;

    [HideInInspector]
    public static int id;
    [HideInInspector]
    public static int character;
    public static GameObject firePoint0;
    public static GameObject firePoint1;

    void Start()
    {
        playerManager.JoinPlayer(0, 0, JoinPlayer.scheme0,JoinPlayer.device0);
        playerManager.JoinPlayer(1, 0, JoinPlayer.scheme1,JoinPlayer.device1);
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        id = playerInput.playerIndex;
        if (id == 0)
        {
            playerInput.gameObject.name = "Player0";
            character = CursorDetection.pickedPlayer0;
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[character];

            firePoint0 = new GameObject("FirePoint0");
            firePoint0.transform.SetParent(playerInput.gameObject.transform);     
            firePoint0.transform.position = new Vector3 (playerInput.gameObject.transform.position.x + 1f, playerInput.gameObject.transform.position.y, playerInput.transform.position.z);       
            //firePoint.transform.position = playerInput.gameObject.transform.position;
        }
        else if (id == 1)
        {
            playerInput.gameObject.name = "Player1";
            character = CursorDetection.pickedPlayer1;
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[character];
            playerInput.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            playerInput.gameObject.GetComponent<PlayerMovement>().isFacingRight = false;

            firePoint1 = new GameObject("FirePoint1");
            firePoint1.transform.SetParent(playerInput.gameObject.transform);     
            firePoint1.transform.position = new Vector3 (playerInput.gameObject.transform.position.x - 1f, playerInput.gameObject.transform.position.y, playerInput.transform.position.z);    
            //firePoint.transform.position = playerInput.gameObject.transform.position;
        }
        //playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id + 2 * Random.Range(0,3)].position;
        // KEEP for later
        playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id].position;
    }
}

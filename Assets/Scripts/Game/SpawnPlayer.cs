using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class SpawnPlayer : MonoBehaviour
{
    public Transform[] spawnLocations;
    public PlayerInputManager playerManager;
    public SpriteLibraryAsset[] sla;

    private int id;
    private GameObject firePoint;

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
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[CursorDetection.pickedPlayer0];

            firePoint = new GameObject("FirePoint0");
            firePoint.transform.SetParent(playerInput.gameObject.transform);     
            firePoint.transform.position = new Vector3 (playerInput.gameObject.transform.position.x + 0.5f, playerInput.gameObject.transform.position.y, playerInput.transform.position.z);       
            //firePoint.transform.position = playerInput.gameObject.transform.position;
        }
        if (id == 1)
        {
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[CursorDetection.pickedPlayer1];
            playerInput.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            playerInput.gameObject.GetComponent<PlayerMovement>().isFacingRight = false;

            firePoint = new GameObject("FirePoint1");
            firePoint.transform.SetParent(playerInput.gameObject.transform);     
            //firePoint.transform.position = new Vector3 (playerInput.gameObject.transform.position.x + 50f, playerInput.gameObject.transform.position.y, 0f);
            firePoint.transform.position = playerInput.gameObject.transform.position;
        }
        //playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id + 2 * Random.Range(0,3)].position;
        // KEEP for later
        playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id].position;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class SpawnPlayer : MonoBehaviour
{
    public Transform[] spawnLocations;
    public PlayerInputManager playerManager;
    public SpriteLibraryAsset[] sla;

    private int id;

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
            //playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = characters[CursorDetection.pickedPlayer0];
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[0];
            
        }
        if (id == 1)
        {
            //playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = characters[CursorDetection.pickedPlayer1];
            playerInput.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = sla[1];
            playerInput.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            playerInput.gameObject.GetComponent<PlayerMovement>().isFacingRight = false;
        }
        //playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id + 2 * Random.Range(0,3)].position;
        // KEEP for later
        playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id].position;
    }
}

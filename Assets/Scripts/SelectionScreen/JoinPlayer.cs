using UnityEngine;
using UnityEngine.InputSystem;


public class JoinPlayer : MonoBehaviour
{   
    public GameObject[] enter;
    public GameObject[] players;
    public GameObject[] squares;

    public Transform[] spawnLocations;
    public Transform canvas;
    public PlayerInputManager playerManager;
    public static InputDevice device0;
    public static InputDevice device1;
    public static string scheme0;
    public static string scheme1;

    private PlayerInput pl0;
    private PlayerInput pl1;
    private int id;

    void Update()
    {
        if (playerManager.playerCount == 2)
        {
            pl0.gameObject.GetComponent<CursorDetection>().allIn = true;
            pl1.gameObject.GetComponent<CursorDetection>().allIn = true;
            playerManager.DisableJoining();
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {    
        id = playerInput.playerIndex;
        if (id == 0)
        {
            pl0 = playerInput;
            device0 = playerInput.devices[0];
            scheme0 = playerInput.currentControlScheme;
        }

        else if (id == 1)
        {
            pl1 = playerInput;
            device1 = playerInput.devices[0];
            scheme1 = playerInput.currentControlScheme;
        }

        playerInput.gameObject.GetComponent<CursorDetection>().playerID = id;
        playerInput.gameObject.GetComponent<CursorMovement>().startPos = spawnLocations[id].position;
        playerInput.gameObject.transform.SetParent(canvas);
        playerInput.gameObject.transform.SetAsLastSibling();
        playerInput.gameObject.name = "Player" + id;

        

        if (!players[id].activeSelf)
        {
            players[id].SetActive(true);
            enter[id].SetActive(false);
            squares[id].SetActive(true);
        }
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        id = playerInput.playerIndex;
        players[id].SetActive(false);
        enter[id].SetActive(true);
        squares[id].SetActive(false);
    }
}
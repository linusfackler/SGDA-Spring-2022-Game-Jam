using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayer : MonoBehaviour
{   
    public GameObject[] enter;
    public GameObject[] players;
    public GameObject[] squares;

    public Transform[] spawnLocations;
    public Transform canvas;

    private int id;

    public void OnPlayerJoined(PlayerInput playerInput)
    {    
        id = playerInput.playerIndex;
        playerInput.gameObject.GetComponent<CursorDetection>().playerID = id;
        playerInput.gameObject.GetComponent<CursorMovement>().startPos = spawnLocations[id].position;
        playerInput.gameObject.transform.SetParent(canvas);
        playerInput.gameObject.transform.SetAsLastSibling();
        playerInput.gameObject.name = "Player" + id;

        //playerInput.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

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
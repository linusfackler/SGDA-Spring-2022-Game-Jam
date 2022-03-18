using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.UI;

public class JoinPlayer : MonoBehaviour
{   
    public GameObject[] enter;
    public GameObject[] players;

    public Transform[] spawnLocations;
    public Transform canvas;

    private int id;

    public void OnPlayerJoined(PlayerInput playerInput)
    {    
        id = playerInput.playerIndex;
        playerInput.gameObject.GetComponent<CursorMovement>().playerID = id + 1;
        playerInput.gameObject.GetComponent<CursorMovement>().startPos = spawnLocations[id].position;
        playerInput.gameObject.transform.SetParent(canvas);
        playerInput.gameObject.transform.SetAsLastSibling();
        playerInput.gameObject.name = "Player" + id;

        playerInput.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        if (!players[id].activeSelf)
        {
            players[id].SetActive(true);
            enter[id].SetActive(false);
        }
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        id = playerInput.playerIndex;
        players[id].SetActive(false);
        enter[id].SetActive(true);
    }
}
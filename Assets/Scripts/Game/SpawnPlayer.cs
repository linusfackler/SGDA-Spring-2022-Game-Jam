using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayer : MonoBehaviour
{
    public Transform[] spawnLocations;
    public Sprite[] characters;
    //public int charact;

    private int id;

    void Start()
    {

    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        id = playerInput.playerIndex;
        if (id == 0)
        {
            playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = characters[CursorDetection.pickedPlayer0];
        }
        if (id == 1)
        {
            playerInput.gameObject.GetComponent<SpriteRenderer>().sprite = characters[CursorDetection.pickedPlayer1];
        }

        playerInput.gameObject.GetComponent<PlayerMovement>().startPos = spawnLocations[id].position;
    }
}

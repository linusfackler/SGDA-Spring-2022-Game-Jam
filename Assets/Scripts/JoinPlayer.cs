using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.UI;

public class JoinPlayer : MonoBehaviour
{    
    public GameObject playerRed;
    public GameObject playerBlue;
    public GameObject pressEnterRed;
    public GameObject pressEnterBlue;

    public Transform[] spawnLocations;
    public Transform canvas;

    public void OnPlayerJoined(PlayerInput playerInput)
    {    

        playerInput.gameObject.GetComponent<CursorMovement>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<CursorMovement>().startPos = spawnLocations[playerInput.playerIndex].position;
        playerInput.gameObject.transform.SetParent(canvas);
        playerInput.gameObject.transform.SetAsLastSibling();

        playerInput.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);


        if (!playerRed.activeSelf)
        {
            playerRed.SetActive(true);
            pressEnterRed.SetActive(false);
        }
        else if (!playerBlue.activeSelf)
        {
            playerBlue.SetActive(true);
            pressEnterBlue.SetActive(false);
        }
        else
            return;
    }
}

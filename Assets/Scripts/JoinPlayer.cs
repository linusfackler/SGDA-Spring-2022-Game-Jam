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

    public void OnPlayerJoined(PlayerInput playerInput)
    {    
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
        print("landed in joined function");
        if (!playerRed.activeSelf)
        {
            playerRed.SetActive(true);
            pressEnterRed.SetActive(false);
            // redStart.Select();
        }
        else if (!playerBlue.activeSelf)
        {
            playerBlue.SetActive(true);
            pressEnterBlue.SetActive(false);
        }

        // if all players joine already, do nothing
        else
        {
            return;
        }
    }
}

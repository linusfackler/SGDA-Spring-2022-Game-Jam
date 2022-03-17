using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.Users;

public class JoinPlayer : MonoBehaviour
{    
    public GameObject playerRed;
    public GameObject playerBlue;
    public GameObject pressEnterRed;
    public GameObject pressEnterBlue;
    // public Button redStart;

    // adding player id to log
    void OnPlayerJoined(PlayerInput playerInput)
    {    
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);
    }

    // join function added
    // makes player selected by p1 and p2 visible
    public void Join(InputAction.CallbackContext context)
    {
        if (context.started)
        {
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
}

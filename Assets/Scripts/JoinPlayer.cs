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
    public Button redStart;
    public Button blueStart;


    public void Join(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!playerRed.activeSelf)
            {
                playerRed.SetActive(true);
                pressEnterRed.SetActive(false);
                redStart.Select();
            }
            else if (!playerBlue.activeSelf)
            {
                playerBlue.SetActive(true);
                pressEnterBlue.SetActive(false);
                blueStart.Select();
            }

            else
            {
                return;
            }
        }

    }
}

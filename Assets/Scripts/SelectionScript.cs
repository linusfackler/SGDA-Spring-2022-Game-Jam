using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SelectionScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    Image img;
    public GameObject red;
    public GameObject blue;

    public GameObject playerBlue;
    public GameObject select;

    public Button blueStart;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        red.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        red.SetActive(false);
    }

    public void Join(InputAction.CallbackContext context)
    {
        if (!playerBlue.activeSelf)
        {
            playerBlue.SetActive(true);
            select.SetActive(false);
            blueStart.Select();
        }

        else
        {
            return;
        }
    }
}

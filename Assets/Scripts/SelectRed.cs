using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SelectRed : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    //public GameObject red;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        //red.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //red.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}

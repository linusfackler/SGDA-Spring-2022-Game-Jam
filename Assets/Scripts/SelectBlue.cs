using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SelectBlue : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    //public GameObject blue;

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        //blue.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //blue.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeTextColor : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TMP_Text>().color = Color.white;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TMP_Text>().color = Color.black;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeTextColor : MonoBehaviour, ISelectHandler, IDeselectHandler {

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TMP_Text>().color = new Color(255, 255, 255, 255);

    }

    public void OnDeselect(BaseEventData eventData)
    {
        gameObject.GetComponentInChildren<TMP_Text>().color = new Color(0, 0, 0, 255);

    }
}
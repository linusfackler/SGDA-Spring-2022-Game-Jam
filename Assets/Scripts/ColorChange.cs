using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour
{
    public Button buttonObject;
    GameObject currentSelected;
    TextMeshPro textObject;


    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
        textObject = gameObject.GetComponent<TextMeshPro>();

        if (currentSelected.name == buttonObject.name)
        {
            textObject.color = Color.white;
            Debug.Log("Selected");
        }

        else
        {
            textObject.color = Color.black;
            Debug.Log("Not Selected");
        }
    }
}

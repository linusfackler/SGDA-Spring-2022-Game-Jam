using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Sprite[] characters;
    private GameObject current;
    private int objectID;

    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        // if at least 1 result is found, change. Otherwise keep the same
        if (results.Count > 0)
        {
            objectID = int.Parse(results[0].gameObject.name);
            
            if (this.gameObject.name == "Player0")
            {
                current = GameObject.Find("RedIMG");
                current.GetComponent<Image>().sprite = characters[objectID];
            }

            else if (this.gameObject.name == "Player1")
            {
                current = GameObject.Find("BlueIMG");
                current.GetComponent<Image>().sprite = characters[objectID];
            }
        }
    }
}

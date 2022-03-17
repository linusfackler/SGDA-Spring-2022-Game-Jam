using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
    }

    void Update()
    {
        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            
        }
    }
}

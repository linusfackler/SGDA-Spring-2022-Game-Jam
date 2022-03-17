using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Rigidbody2D rb;

    void Start()
    {
        gr = GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        pointerEventData.position = Camera.main.WorldToScreenPoint(rb.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (results.Count > 0)
        {
            print(results[0].gameObject.name);
        }
    }
    // Ray ray;
    // RaycastHit hit;

    // void Update()
    // {
    //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if(Physics.Raycast(ray, out hit))
    //     {
    //         print (hit.collider.name);
    //     }
    // }
}

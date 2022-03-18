using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Sprite[] characters;
    public GameObject[] texts;
    public bool chosen = false;
    public int pickedPlayer;

    private GameObject current, redIMG, blueIMG, blueSquare, redSquare;
    private int objectID;
    private Vector3 boxPosition;

    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
        redIMG = GameObject.Find("RedIMG");
        blueIMG = GameObject.Find("BlueIMG");
        redSquare = GameObject.Find("RedSquare");
        blueSquare = GameObject.Find("BlueSquare");

    }

    void Update()
    {
        pointerEventData.position = transform.position;
        print("pointer position: " + pointerEventData.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        // if at least 1 result is found, change. Otherwise keep the same

        if (!chosen)
        {
            if (results.Count > 0)
            {
                boxPosition = new Vector3(results[0].gameObject.transform.position.x, results[0].gameObject.transform.position.y + 22f, results[0].gameObject.transform.position.z);
                print(boxPosition);
                print(results[0].gameObject.name);
                objectID = int.Parse(results[0].gameObject.name);
                
                if (this.gameObject.name == "Player0")
                {
                    current = redIMG;
                    current.GetComponent<Image>().sprite = characters[objectID];
                    GameObject.Find("Player1name").GetComponent<TMP_Text>().text = characters[objectID].name;
                    redSquare.SetActive(true);
                    redSquare.transform.position = boxPosition;
                }

                else if (this.gameObject.name == "Player1")
                {
                    current = blueIMG;
                    current.GetComponent<Image>().sprite = characters[objectID];
                    GameObject.Find("Player2name").GetComponent<TMP_Text>().text = characters[objectID].name;
                    blueSquare.SetActive(true);
                    blueSquare.transform.position = boxPosition;
                }
            }

            else
            {
                if (this.gameObject.name == "Player0")
                {
                    redSquare.SetActive(false);
                }

                else if (this.gameObject.name == "Player1")
                {
                    blueSquare.SetActive(false);
                }
            }
        }
        
    }

    public void Select(InputAction.CallbackContext context)
    {
        if (!chosen)
        {
            pickedPlayer = objectID;
            chosen = true;
        }
    }

    public void Back(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (chosen)
            {
                chosen = false;
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }
}

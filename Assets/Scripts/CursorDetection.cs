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
    public Sprite[] fingers;
    public bool chosen = false;
    public bool done = false;
    public int pickedPlayer;

    private GameObject current, redIMG, blueIMG, blueSquare, redSquare, readyRed, readyBlue, startGame;
    private int objectID;
    private Vector3 boxPosition;
    private int redID, blueID;

    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
        readyBlue = GameObject.Find("ReadyBlue");
        readyRed = GameObject.Find("ReadyRed");
        startGame = GameObject.Find("START");

        if (this.gameObject.name == "Player0")
        {        
            redIMG = GameObject.Find("RedIMG");
            redSquare = GameObject.Find("RedSquare");
            //readyRed.SetActive(false);
            this.gameObject.GetComponent<Image>().sprite = fingers[0];


            // startGame.SetActive(false);
            // startGame.gameObject.transform.SetAsLastSibling();
        }

        else if (this.gameObject.name == "Player1")
        {
            blueIMG = GameObject.Find("BlueIMG");
            blueSquare = GameObject.Find("BlueSquare");
            this.gameObject.GetComponent<Image>().sprite = fingers[1];
            //readyBlue.SetActive(false);
        }
        this.gameObject.GetComponent<Transform>().localScale = new Vector3 (0.2f, 0.2f, 0.2f);
    }

    void Update()
    {
        pointerEventData.position = new Vector3 (transform.position.x - 35f, transform.position.y + 10, transform.position.z);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        // if at least 1 result is found, change. Otherwise keep the same

        if (!chosen && !done)
        {
            if (results.Count > 0)
            {
                boxPosition = new Vector3(results[0].gameObject.transform.position.x, results[0].gameObject.transform.position.y + 22f, results[0].gameObject.transform.position.z);
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
        if (context.performed)
        {
            if (!chosen && !done)
            {
                pickedPlayer = objectID;
                chosen = true;


                if (this.gameObject.name == "Player0")
                {
                    //readyRed.SetActive(true);
                    readyRed.transform.SetAsLastSibling();
                    Debug.Log("Landed here for some reason");
                }

                else if (this.gameObject.name == "Player1")
                {
                    //readyBlue.SetActive(true);
                    readyBlue.transform.SetAsLastSibling();
                }

                redID = readyRed.transform.GetSiblingIndex();
                blueID = readyBlue.transform.GetSiblingIndex();
                //if (readyRed.activeSelf && readyBlue.activeSelf)
                if (redID > 6 && blueID > 6)
                {
                    startGame.gameObject.transform.SetAsLastSibling();
                    done = true;
                }
            }
        }
        
    }

    public void Back(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            redID = readyRed.transform.GetSiblingIndex();
            blueID = readyBlue.transform.GetSiblingIndex();
            
            done = false;
            startGame.gameObject.transform.SetAsFirstSibling();

            chosen = false;

            if (this.gameObject.name == "Player0" && redID > 6)
            {
                //readyRed.SetActive(false);
                readyRed.transform.SetAsFirstSibling();
            }

            else if (this.gameObject.name == "Player1" && blueID > 6)
            {
                //readyBlue.SetActive(false);
                readyBlue.transform.SetAsFirstSibling();
            }

            // else if (this.gameObject.name == "Player0" && redID < 6)
            // {
            //     Destroy(gameObject);
            // }

            else
            {
                Destroy(gameObject);
            }
        }
    }
}

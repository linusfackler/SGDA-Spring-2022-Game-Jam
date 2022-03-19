using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class CursorDetection : MonoBehaviour
{
    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Sprite[] characters;
    public Sprite[] fingers;
    public bool chosen = false;
    public int playerID;
    public bool allIn = false;

    private GameObject current, redIMG, blueIMG, blueSquare, redSquare, readyRed, readyBlue, startGame;
    private int objectID;
    private Vector3 boxPosition;
    private int redID = 0, blueID = 0;
    private bool done;

    public static int pickedPlayer0;
    public static int pickedPlayer1;

    void Start()
    {
        gr = GetComponentInParent<GraphicRaycaster>();
        readyBlue = GameObject.Find("ReadyBlue");
        readyRed = GameObject.Find("ReadyRed");
        startGame = GameObject.Find("START");
        done = false;

        if (playerID == 0)
        {        
            redIMG = GameObject.Find("RedIMG");
            redSquare = GameObject.Find("RedSquare");
            this.gameObject.GetComponent<Image>().sprite = fingers[0];
        }

        else if (playerID == 1)
        {
            blueIMG = GameObject.Find("BlueIMG");
            blueSquare = GameObject.Find("BlueSquare");
            this.gameObject.GetComponent<Image>().sprite = fingers[1];
        }
        this.gameObject.GetComponent<Transform>().localScale = new Vector3 (0.2f, 0.2f, 0.2f);
    }

    void Update()
    {
        pointerEventData.position = new Vector3 (transform.position.x - 35f, transform.position.y + 10f, transform.position.z);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (!chosen && !done)
        {
            if (results.Count > 0)
            {
                boxPosition = new Vector3(results[0].gameObject.transform.position.x, results[0].gameObject.transform.position.y + 30f, results[0].gameObject.transform.position.z);
                objectID = int.Parse(results[0].gameObject.name);
                
                if (playerID == 0)
                {
                    current = redIMG;
                    current.GetComponent<Image>().sprite = characters[objectID];
                    GameObject.Find("Player1name").GetComponent<TMP_Text>().text = characters[objectID].name;
                    redSquare.SetActive(true);
                    redSquare.transform.position = boxPosition;
                }

                else if (playerID == 1)
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
                if (playerID == 0)
                {
                    redSquare.SetActive(false);
                }

                else if (playerID == 1)
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
                chosen = true;

                if (playerID == 0)
                {
                    readyRed.transform.SetAsLastSibling();
                    pickedPlayer0 = objectID;
                }

                else if (playerID == 1)
                {
                    readyBlue.transform.SetAsLastSibling();
                    pickedPlayer1 = objectID;
                }

                redID = readyRed.transform.GetSiblingIndex();
                blueID = readyBlue.transform.GetSiblingIndex();
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

            if (playerID == 0 && redID > 6)
            {
                readyRed.transform.SetAsFirstSibling();
            }

            else if (playerID == 1 && blueID > 6)
            {
                readyBlue.transform.SetAsFirstSibling();
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        if (allIn)
        {
            redID = readyRed.transform.GetSiblingIndex();
            blueID = readyBlue.transform.GetSiblingIndex();
            if (redID > 6 && blueID > 6)
            {
                done = true;
            }
            if (context.started && done)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}

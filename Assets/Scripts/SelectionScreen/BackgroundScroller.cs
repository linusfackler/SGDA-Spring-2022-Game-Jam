using UnityEngine;
using UnityEngine.UI;

 public class BackgroundScroller : MonoBehaviour {
 
    [Range(-1f, 1f)]
    public float scrollSpeed;
    //public Image img;

    private float offset;
    private Material mat;


    void Start()
    {
        mat = GetComponent<Image>().material;
    }
    void Update ()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        //img.material.mainTextureOffset += new Vector2(Time.deltaTime * (-scrollSpeed / 10), 0f);
    }
 }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveDown : MonoBehaviour
{
    // Vector3 startPosition;
    // float whenToRepeat;
    // [SerializeField] float mult = 1;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     startPosition = GetComponent<RectTransform>().anchoredPosition;
    //     //transform.position;
    //     whenToRepeat = GetComponent<BoxCollider2D>().size.y/2;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(GetComponent<RectTransform>().position);
    //     GetComponent<RectTransform>().anchoredPosition -= new Vector2(0,mult*Time.deltaTime);
    //     if(GetComponent<RectTransform>().anchoredPosition.y < startPosition.y - whenToRepeat)
    //     {
    //         GetComponent<RectTransform>().anchoredPosition = startPosition;
    //     }
        
    // }
    
    [SerializeField] RawImage rImg;
    [SerializeField] float speed = 1;
    [SerializeField] float rx;
    [SerializeField] float ry;
    void Start() 
    {
        rImg = GetComponent<RawImage>();
    }

    private void Update()
    {
        rImg.uvRect = new Rect(rImg.uvRect.position + new Vector2(rx, ry) *Time.deltaTime * speed, rImg.uvRect.size);
        
    }

}

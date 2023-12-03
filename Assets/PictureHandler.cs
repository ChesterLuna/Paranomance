using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureHandler : MonoBehaviour
{
    [SerializeField] Sprite[] characterPortraits;
    //[SerializeField] GameObject[] portraitStands;
    [SerializeField] GameObject portraitStand;


    public void UpdatePortrait(int index)
    {
        Debug.Log("The index is");
        Debug.Log(index);
        Debug.Log(characterPortraits.Length);

        portraitStand.GetComponent<Image>().sprite = characterPortraits[index];
    }
}

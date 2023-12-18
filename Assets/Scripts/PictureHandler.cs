using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureHandler : MonoBehaviour
{
    [SerializeField] Sprite[] characterPortraits;
    //[SerializeField] GameObject[] portraitStands;
    [SerializeField] GameObject portraitStand;

    [SerializeField] GameObject pictureDisplayed;
    [SerializeField] bool pictureShown = false;


    public void UpdatePortrait(int index)
    {
        // Debug.Log("The index is");
        // Debug.Log(index);
        // Debug.Log(characterPortraits.Length);

        portraitStand.GetComponent<Image>().sprite = characterPortraits[index];
    }

    public void DisplayPicture()
    {
        if (pictureShown == false)
        {
            pictureDisplayed.SetActive(true);
            pictureShown = true;
            return;
        }
        if (pictureShown == true)
        {
            pictureDisplayed.SetActive(false);
            pictureShown = false;
            return;
        }
    }

}

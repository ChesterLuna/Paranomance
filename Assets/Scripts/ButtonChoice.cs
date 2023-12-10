using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;

public class ButtonChoice : MonoBehaviour
{
    [SerializeField] char choiceValue;
    [SerializeField] string characterAttracted;
    [SerializeField] int attractionPoints;
    [SerializeField] string[] choicesDone;

    public void ChooseChoice()
    {
        FindObjectOfType<TextAnalyzer>().AnalyzeChoice(choiceValue);
        AddToTotal();
        AddToLevel();
        transform.parent.gameObject.SetActive(false);
        transform.parent.transform.parent.Find("Background Choice").GameObject().SetActive(false);
    }

    private void AddToLevel()
    {
        FindObjectOfType<DialogueManager>().attractionAttained += attractionPoints;
    }

    private void AddToTotal()
    {
        if (characterAttracted == "Pirate" || characterAttracted == "Alomar")
            GameSession.Pirate_Attraction += attractionPoints;
        if (characterAttracted == "Victorian" || characterAttracted == "Ollie")
            GameSession.Victorian_Attraction += attractionPoints;
        if (characterAttracted == "Samurai" || characterAttracted == "Mizuki")
            GameSession.Samurai_Attraction += attractionPoints;

        for(int i = 0; i < choicesDone.Length; i++)
        {
            if(choicesDone[i] == "")
            {
                Debug.Log("Empty Choice");
                continue;
            }
            GameSession.Global_Choices[choicesDone[i]] = true;
        }
        
        
    }

}

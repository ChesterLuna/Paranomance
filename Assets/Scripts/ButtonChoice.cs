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
        PerformChoice();
        transform.parent.gameObject.SetActive(false);
    }

    private void PerformChoice()
    {
        if (characterAttracted == "Pirate" || characterAttracted == "Alomar")
            GameSession.Pirate_Attraction += attractionPoints;
        if (characterAttracted == "Victorian" || characterAttracted == "Ollie")
            GameSession.Victorian_Attraction += attractionPoints;
        if (characterAttracted == "Samurai" || characterAttracted == "XXX")
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
        
        
        
        // Debug.Log(GameSession.Pirate_Attraction);
        // Debug.Log(GameSession.Victorian_Attraction);
        // Debug.Log(GameSession.Samurai_Attraction);


        // foreach (KeyValuePair<string, bool> kvp in GameSession.Global_Choices)
        // {
        //     Debug.Log( string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        // }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GeneralButton : MonoBehaviour
{
    public void ChangeScene(string sceneToLoad)
    {
        //string lastScene = "";

        MapHandler handler = FindObjectOfType<MapHandler>();

        if (sceneToLoad[0] == 'P')
        {
            int index = handler.PirateEvents.FindIndex(a => a.Contains(sceneToLoad));
            if (index != 0)
            {
                if (GameSession.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Negative"))
                {
                    sceneToLoad = sceneToLoad + "_Negative";
                }
            }
        }
        else if (sceneToLoad[0] == 'S')
        {
            int index = handler.SamuraiEvents.FindIndex(a => a.Contains(sceneToLoad));
            if (index != 0)
            {
                if (GameSession.Global_Choices.ContainsKey(handler.SamuraiEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Global_Choices.ContainsKey(handler.SamuraiEvents[index - 1] + "_Negative"))
                {
                    sceneToLoad = sceneToLoad + "_Negative";
                }
            }
        }
        else if (sceneToLoad[0] == 'V')
        {
            int index = handler.VictorianEvents.FindIndex(a => a.Contains(sceneToLoad));
            if (index != 0)
            {
                if (GameSession.Global_Choices.ContainsKey(handler.VictorianEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Global_Choices.ContainsKey(handler.VictorianEvents[index - 1] + "_Negative"))
                {
                    sceneToLoad = sceneToLoad + "_Negative";
                }
            }
        }

        GameSession.NightsLeft--;

        SceneManager.LoadScene(sceneToLoad);
        // else
        //     Debug.LogErrorFormat(sceneToLoad);

    }

    public void ChangeSceneToEnding()
    {
        List<string> possibleEndings = new List<string>();
        string selectedEnding = "Neutral";
        int maxAttraction = 0;


        // || 
        
        if (GameSession.Global_Choices["P_Pool"] == true && GameSession.Pirate_Attraction >= 5)
        {
            if(GameSession.Pirate_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Pirate_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("P");
            }
            else if(GameSession.Pirate_Attraction == maxAttraction)
            {
                possibleEndings.Add("P");
            }
        }
        if (GameSession.Global_Choices["S_Roof"] == true && GameSession.Samurai_Attraction >= 5)
        {
            if (GameSession.Samurai_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Samurai_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("S");
            }
            else if (GameSession.Samurai_Attraction == maxAttraction)
            {
                possibleEndings.Add("S");
            }
        }
        if (GameSession.Global_Choices["V_Bathroom"] == true && GameSession.Victorian_Attraction >= 5)
        {
            if (GameSession.Victorian_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Victorian_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("V");
            }
            else if (GameSession.Victorian_Attraction == maxAttraction)
            {
                possibleEndings.Add("V");
            }
        }

        if (possibleEndings.Count != 0)
        {
            int randInd = UnityEngine.Random.Range(0, possibleEndings.Count);
            selectedEnding = possibleEndings[randInd];
        }

        SceneManager.LoadScene(selectedEnding + "_Ending");

    }


    public void DisplayMenu(bool display)
    {
        Transform theCanvas = gameObject.transform.root.gameObject.transform;
        theCanvas.Find("Menu HUD").GameObject().SetActive(display);
        theCanvas.Find("Open Menu").GameObject().SetActive(!display);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }

}

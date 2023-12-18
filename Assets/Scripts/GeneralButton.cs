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
                if (GameSession.Instance.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Instance.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Negative"))
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
                if (GameSession.Instance.Global_Choices.ContainsKey(handler.SamuraiEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Instance.Global_Choices.ContainsKey(handler.SamuraiEvents[index - 1] + "_Negative"))
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
                if (GameSession.Instance.Global_Choices.ContainsKey(handler.VictorianEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Instance.Global_Choices.ContainsKey(handler.VictorianEvents[index - 1] + "_Negative"))
                {
                    sceneToLoad = sceneToLoad + "_Negative";
                }
            }
        }

        if(SceneManager.GetActiveScene().name == "House Map")
            GameSession.Instance.NightsLeft--;


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
        
        if (GameSession.Instance.Global_Choices["P_Pool"] == true && GameSession.Instance.Pirate_Attraction >= 5)
        {
            if(GameSession.Instance.Pirate_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Instance.Pirate_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("P");
            }
            else if(GameSession.Instance.Pirate_Attraction == maxAttraction)
            {
                possibleEndings.Add("P");
            }
        }
        if (GameSession.Instance.Global_Choices["S_Roof"] == true && GameSession.Instance.Samurai_Attraction >= 5)
        {
            if (GameSession.Instance.Samurai_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Instance.Samurai_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("S");
            }
            else if (GameSession.Instance.Samurai_Attraction == maxAttraction)
            {
                possibleEndings.Add("S");
            }
        }
        if (GameSession.Instance.Global_Choices["V_Bathroom"] == true && GameSession.Instance.Victorian_Attraction >= 5)
        {
            if (GameSession.Instance.Victorian_Attraction > maxAttraction)
            {
                maxAttraction = GameSession.Instance.Victorian_Attraction;
                possibleEndings.Clear();
                possibleEndings.Add("V");
            }
            else if (GameSession.Instance.Victorian_Attraction == maxAttraction)
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

    // public void SaveGame()
    // {
    //     var writer = QuickSaveWriter.Create("Quick");
    //     writer.Write("LastScene", SceneManager.GetActiveScene().name);

    //     writer.Write("Session", GameSession.Instance);
    //     writer.Write("NameQueue", FindObjectOfType<DialogueManager>().names);
    //     writer.Write("DialogueQueue", FindObjectOfType<DialogueManager>().dialogues);
    //     writer.Commit();
    // }

    // public void LoadGame()
    // {

    //     // Here we read the data we saved in the section above
    //     var reader = QuickSaveReader.Create("Quick");
    //     SceneManager.LoadScene(reader.Read<string>("LastScene"));

    //     //DELETE GAME OBJECT FROM THE NEW SCENE
    //     GameObject.FindObjectOfType<GameSession>().resetGame();
    //     //CREATE A NEW GAME SESSION
    //     Instantiate(reader.Read<GameSession>("Session"));

    //     //GameSession.Instance
    //     FindObjectOfType<DialogueManager>().names = reader.Read<Queue<string>>("NameQueue");
    //     FindObjectOfType<DialogueManager>().dialogues = reader.Read<Queue<string>>("DialogueQueue");

    // }


    public void LoadMainMenu()
    {
        GameSession.Instance.resetGame();
        GameSession.Instance = null;
        SceneManager.LoadScene("Main Menu");

    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }

}

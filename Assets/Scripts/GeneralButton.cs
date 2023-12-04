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
        string lastScene = "";

        MapHandler handler = FindObjectOfType<MapHandler>();

        if (sceneToLoad[0] == 'P')
        {

            int index = handler.PirateEvents.FindIndex(a => a.Contains(sceneToLoad));
            Debug.Log("index");
            Debug.Log(index);


            if (0 == index)
            {
                sceneToLoad = sceneToLoad;
            }
            else
            {
                Debug.Log(handler.PirateEvents[index - 1]);

                if (GameSession.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Positive"))
                {
                    sceneToLoad = sceneToLoad + "_Positive";
                }
                else if (GameSession.Global_Choices.ContainsKey(handler.PirateEvents[index - 1] + "_Negative"))
                {
                    sceneToLoad = sceneToLoad + "_Negative";
                }
            }
            //FindObjectOfType<MapHandler>().PirateEvents().
        }

        // string lastScene()


        // if(lastScene == "")

        // if(GameSession.Global_Choices.ContainsKey(sceneToLoad + "_Positive"))
        //     SceneManager.LoadScene(sceneToLoad + "_Positive");
        // else if (GameSession.Global_Choices.ContainsKey(sceneToLoad + "_Negative"))
        //     SceneManager.LoadScene(sceneToLoad + "_Negative");
        // else if (GameSession.Global_Choices.ContainsKey(sceneToLoad))
        SceneManager.LoadScene(sceneToLoad);
        // else
        //     Debug.LogErrorFormat(sceneToLoad);

    }


    public void DisplayMenu(bool display)
    {
        GameObject.Find("Menu Canvas").transform.Find("Menu HUD").GameObject().SetActive(display);
        GameObject.Find("Menu Canvas").transform.Find("Open Menu").GameObject().SetActive(!display);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
        
    }

}

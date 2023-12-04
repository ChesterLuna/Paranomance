using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButton : MonoBehaviour
{

    public void ChangeScene(string sceneToLoad)
    {
        Debug.Log(sceneToLoad + "_Positive");
        if(GameSession.Global_Choices.ContainsKey(sceneToLoad + "_Positive"))
            SceneManager.LoadScene(sceneToLoad + "_Positive");
        else if (GameSession.Global_Choices.ContainsKey(sceneToLoad + "_Negative"))
            SceneManager.LoadScene(sceneToLoad + "_Negative");

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

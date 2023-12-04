using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButton : MonoBehaviour
{

    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
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

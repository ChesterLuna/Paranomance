using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration parameters

    // static public Dictionary<string, bool> Pirate_Choices = new Dictionary<string, bool>();
    // static public Dictionary<string, bool> Victorian_Choices = new Dictionary<string, bool>();
    // static public Dictionary<string, bool> Samurai_Choices = new Dictionary<string, bool>();
    // // Ex: Pirate_Choices["First_Event_Success"] = true
    [SerializeField] static public Dictionary<string, bool> Global_Choices = new Dictionary<string, bool>();

    static public int Pirate_Attraction;
    static public int Victorian_Attraction;
    static public int Samurai_Attraction;


    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;

    private void Awake()
    {
        SetUpSingleton();
        Pirate_Attraction = 0;
        Victorian_Attraction = 0;
        Samurai_Attraction = 0;

    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

    }



    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // public int GetAttraction(string character)
    // {
    //     if (character == "Pirate" || character == "Alomar")
    //         return Pirate_Attraction;
    //     if (character == "Victorian" || character == "Ollie")
    //         GameSession.Victorian_Attraction += attractionPoints;
    //     if (character == "Samurai" || character == "XXX")
    //         GameSession.Samurai_Attraction += attractionPoints;

    // }

    // public void AddToScore(int scoreValue)
    // {
    //     score += scoreValue;
    // }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    public static GameSession Instance;

    // [SerializeField] static public Dictionary<string, bool> Global_Choices = new Dictionary<string, bool>();

    // static public int Pirate_Attraction;
    // static public int Victorian_Attraction;
    // static public int Samurai_Attraction;

    // static public int NightsLeft;

    // static public string NameOfProtagonist = "Danielle";

    //public string debugTest= "funciono";



    [SerializeField] public Dictionary<string, bool> Global_Choices = new Dictionary<string, bool>();

    public int Pirate_Attraction;
    public int Victorian_Attraction;
    public int Samurai_Attraction;

    public int NightsLeft;

    public string NameOfProtagonist = "Danielle";


    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] GameObject prefabInput;

    private void Awake()
    {
        SetUpSingleton();
        if (!GameSession.Instance.Global_Choices.ContainsKey("P_Garage"))
        {
            GameSession.Instance.NightsLeft = 7;
            GameSession.Instance.Global_Choices["P_Garage"] = false;
            GameSession.Instance.Global_Choices["P_Common_Room"] = false;
            GameSession.Instance.Global_Choices["P_Pool"] = false;
            GameSession.Instance.Global_Choices["S_Garden"] = false;
            GameSession.Instance.Global_Choices["S_Kitchen"] = false;
            GameSession.Instance.Global_Choices["S_Roof"] = false;
            GameSession.Instance.Global_Choices["V_Attic"] = false;
            GameSession.Instance.Global_Choices["V_Library"] = false;
            GameSession.Instance.Global_Choices["V_Bathroom"] = false;

        }

    }

    private void Start()
    {
        GameSession.Instance.Pirate_Attraction = 0;
        GameSession.Instance.Victorian_Attraction = 0;
        GameSession.Instance.Samurai_Attraction = 0;
        
        if(NameOfProtagonist == "DEBUG")
        {
            Instantiate(prefabInput);
        }

        // CHOOSE YOUR NAME

    }
    private void SetUpSingleton()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }


        // int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        // if (numberGameSessions > 1)
        // {
        //     Destroy(gameObject);

        // }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);

        // }

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
    //         GameSession.Instance.Victorian_Attraction += attractionPoints;
    //     if (character == "Samurai" || character == "XXX")
    //         GameSession.Instance.Samurai_Attraction += attractionPoints;

    // }

    // public void AddToScore(int scoreValue)
    // {
    //     score += scoreValue;
    // }

    public void resetGame()
    {
        GameSession.Instance = null;

        Destroy(gameObject);
    }
}

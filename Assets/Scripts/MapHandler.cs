using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [SerializeField] GameObject MapCanvas;
    int totalNights = 7;
    [SerializeField] int nightsLeft = 7;
    [SerializeField] TextMeshProUGUI mapDialogue;
    [SerializeField] string[] nightsText;

    public List<string> PirateEvents = new List<string>() { "P_Garage", "P_Common_Room", "P_Pool" };
    public List<string> SamuraiEvents = new List<string>() { "S_Kitchen", "S_Garden", "S_Roof" };
    public List<string> VictorianEvents = new List<string>() { "V_Attic", "V_Bathroom", "V_Library" };

    // Start is called before the first frame update
    void Start()
    {
        // foreach (KeyValuePair<string, bool> kvp in GameSession.Instance.Global_Choices)
        // {
        //     //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        //     Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        // }
        nightsLeft = GameSession.Instance.NightsLeft;
        mapDialogue.text = nightsText[totalNights - nightsLeft];

        Debug.Log(GameSession.Instance.Global_Choices["P_Garage"]);;

        if(nightsLeft == 0)
        {
            GameObject.Find("Conv Canvas").transform.Find("Forced Ending Button").GameObject().SetActive(true);
            //GameObject.Find("Forced Ending Button").SetActive(true);
            //TurnButtonOn("Master_Room");
            return;
        }

        // PIRATE STUFF
        if (GameSession.Instance.Global_Choices["P_Garage"] == false
        && GameSession.Instance.Global_Choices["P_Common_Room"] == false
        && GameSession.Instance.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Garage");
        }
        if (GameSession.Instance.Global_Choices["P_Garage"] == true
        && GameSession.Instance.Global_Choices["P_Common_Room"] == false
        && GameSession.Instance.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Common_Room");
        }
        if (GameSession.Instance.Global_Choices["P_Garage"] == true
        && GameSession.Instance.Global_Choices["P_Common_Room"] == true
        && GameSession.Instance.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Pool");
        }
        if(GameSession.Instance.Global_Choices["P_Pool"] == true)
        {
            TurnButtonOn("Master_Room");
        }

        // SAMURAI STUFF
        if (GameSession.Instance.Global_Choices["S_Kitchen"] == false
        && GameSession.Instance.Global_Choices["S_Garden"] == false
        && GameSession.Instance.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Kitchen");
        }
        if (GameSession.Instance.Global_Choices["S_Kitchen"] == true
        && GameSession.Instance.Global_Choices["S_Garden"] == false
        && GameSession.Instance.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Garden");
        }
        if (GameSession.Instance.Global_Choices["S_Kitchen"] == true
        && GameSession.Instance.Global_Choices["S_Garden"] == true
        && GameSession.Instance.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Roof");
        }
        if (GameSession.Instance.Global_Choices["S_Roof"] == true)
        {
            TurnButtonOn("Master_Room");
        }

        // VICTORIAN STUFF
        if (GameSession.Instance.Global_Choices["V_Attic"] == false
        && GameSession.Instance.Global_Choices["V_Bathroom"] == false
        && GameSession.Instance.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Attic");
        }
        if (GameSession.Instance.Global_Choices["V_Attic"] == true
        && GameSession.Instance.Global_Choices["V_Bathroom"] == false
        && GameSession.Instance.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Bathroom");
        }
        if (GameSession.Instance.Global_Choices["V_Attic"] == true
        && GameSession.Instance.Global_Choices["V_Bathroom"] == true
        && GameSession.Instance.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Library");
        }
        if (GameSession.Instance.Global_Choices["V_Library"] == true)
        {
            TurnButtonOn("Master_Room");
        }

    }

    private void TurnButtonOn(string roomName)
    {
        MapCanvas.transform.Find(roomName).GameObject().SetActive(true);

    }

}

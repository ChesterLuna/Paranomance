using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [SerializeField] GameObject MapCanvas;

    public List<string> PirateEvents = new List<string>() { "P_Garage", "P_Common_Room", "P_Pool" };
    public List<string> SamuraiEvents = new List<string>() { "S_Kitchen", "S_Garden", "S_Roof" };
    public List<string> VictorianEvents = new List<string>() { "V_Attic", "V_Bathroom", "V_Library" };
    // Start is called before the first frame update
    void Start()
    {
        // foreach (KeyValuePair<string, bool> kvp in GameSession.Global_Choices)
        // {
        //     //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        //     Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        // }

        Debug.Log(GameSession.Global_Choices["P_Garage"]);
        Debug.Log(GameSession.Global_Choices["P_Common_Room"]);
        Debug.Log(GameSession.Global_Choices["P_Pool"]);

        // PIRATE STUFF
        if (GameSession.Global_Choices["P_Garage"] == false
        && GameSession.Global_Choices["P_Common_Room"] == false
        && GameSession.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Garage");
        }
        if (GameSession.Global_Choices["P_Garage"] == true
        && GameSession.Global_Choices["P_Common_Room"] == false
        && GameSession.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Common_Room");
        }
        if (GameSession.Global_Choices["P_Garage"] == true
        && GameSession.Global_Choices["P_Common_Room"] == true
        && GameSession.Global_Choices["P_Pool"] == false)
        {
            TurnButtonOn("Pool");
        }
        if(GameSession.Global_Choices["P_Pool"] == true)
        {
            TurnButtonOn("Master_Room");
        }

        // SAMURAI STUFF
        if (GameSession.Global_Choices["S_Kitchen"] == false
        && GameSession.Global_Choices["S_Garden"] == false
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Kitchen");
        }
        if (GameSession.Global_Choices["S_Kitchen"] == true
        && GameSession.Global_Choices["S_Garden"] == false
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Garden");
        }
        if (GameSession.Global_Choices["S_Kitchen"] == true
        && GameSession.Global_Choices["S_Garden"] == true
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Roof");
        }
        if (GameSession.Global_Choices["S_Roof"] == true)
        {
            TurnButtonOn("Master_Room");
        }

        // VICTORIAN STUFF
        if (GameSession.Global_Choices["V_Attic"] == false
        && GameSession.Global_Choices["V_Bathroom"] == false
        && GameSession.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Attic");
        }
        if (GameSession.Global_Choices["V_Attic"] == true
        && GameSession.Global_Choices["V_Bathroom"] == false
        && GameSession.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Bathroom");
        }
        if (GameSession.Global_Choices["V_Attic"] == true
        && GameSession.Global_Choices["V_Bathroom"] == true
        && GameSession.Global_Choices["V_Library"] == false)
        {
            TurnButtonOn("Library");
        }
        if (GameSession.Global_Choices["V_Library"] == true)
        {
            TurnButtonOn("Master_Room");
        }

    }

    private void TurnButtonOn(string roomName)
    {
        MapCanvas.transform.Find(roomName).GameObject().SetActive(true);

    }

}

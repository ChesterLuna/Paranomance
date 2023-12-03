using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    [SerializeField] GameObject MapCanvas;
    // Start is called before the first frame update
    void Start()
    {

        // PIRATE STUFF
        if(GameSession.Global_Choices["P_Garage"] == false
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
        
        // SAMURAI STUFF
        if (GameSession.Global_Choices["S_Garden"] == false
        && GameSession.Global_Choices["S_Kitchen"] == false
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Garden");
        }
        if (GameSession.Global_Choices["S_Garden"] == true
        && GameSession.Global_Choices["S_Kitchen"] == false
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Kitchen");
        }
        if (GameSession.Global_Choices["S_Garden"] == true
        && GameSession.Global_Choices["S_Kitchen"] == true
        && GameSession.Global_Choices["S_Roof"] == false)
        {
            TurnButtonOn("Roof");
        }


        // VICTORIAN STUFF
        if (GameSession.Global_Choices["V_Study"] == false
        && GameSession.Global_Choices["V_Storage_Room"] == false
        && GameSession.Global_Choices["V_Bathroom"] == false)
        {
            TurnButtonOn("Study");
        }
        if (GameSession.Global_Choices["V_Study"] == true
        && GameSession.Global_Choices["V_Storage_Room"] == false
        && GameSession.Global_Choices["V_Bathroom"] == false)
        {
            TurnButtonOn("Storage_Room");
        }
        if (GameSession.Global_Choices["V_Study"] == true
        && GameSession.Global_Choices["V_Storage_Room"] == true
        && GameSession.Global_Choices["V_Bathroom"] == false)
        {
            TurnButtonOn("Bathroom");
        }
    }

    private void TurnButtonOn(string roomName)
    {
        MapCanvas.transform.Find(roomName).GameObject().SetActive(true);

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputName : MonoBehaviour
{


    public void ChangeProtagonistName()
    {
        GameSession.Instance.NameOfProtagonist = GetComponent<TMP_InputField>().text;
        Destroy(GameObject.Find("Select Name Canvas(Clone)"));

    }

}

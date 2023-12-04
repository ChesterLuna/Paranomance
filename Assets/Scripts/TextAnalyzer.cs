using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextAnalyzer : MonoBehaviour
{
    [SerializeField] TextAsset AssetText;

    int i = 0;

    DialogueManager manager;
    string txt;
    string[] lines;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
        txt = AssetText.text;
        lines = txt.Split(System.Environment.NewLine.ToCharArray());


    }
    void Start()
    {
        // Debug.Log("Splitted text");

    }

    public void AnalyzeText()
    {
        // Debug.Log("Entra aqui");
        // Debug.Log("Lines are " + lines.Length.ToString());

        while (i < lines.Length)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                if (lines[i][0] == '#')
                {
                    if(lines[i].Remove(0, 1) == "")
                        manager.names.Enqueue(" ");
                    else
                        manager.names.Enqueue(lines[i].Remove(0, 1));
                }
                if (lines[i][0] == ':')
                {
                    manager.dialogues.Enqueue(lines[i].Remove(0, 1));
                }
                if (lines[i][0] == '@')
                {
                    manager.names.Enqueue(lines[i]);
                }

                if (lines[i][0] == '[')
                {
                    // Debug.Log("Si pongo el choice");
                    manager.names.Enqueue("Choice");
                    manager.dialogues.Enqueue("Choice");

                    i++;
                    // Debug.Log(i);
                    break;
                }
            }
            i++;
        }
    }

    public void AnalyzeChoice(char choice)
    {

        while (i < lines.Length)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                if (lines[i][0] == ']')
                {
                    // Debug.Log("Reconoce la ]");
                    i++;
                    AnalyzeText();
                    manager.DisplayNextSentence();
                    break;
                }
                if(lines[i][0] == choice)
                {
                    if (lines[i][1] == '@')
                    {
                        manager.names.Enqueue(lines[i].Remove(0, 1));
                    }
                    if (lines[i][1] == '#')
                    {
                        if (lines[i].Remove(0, 2) == "")
                            manager.names.Enqueue(" ");
                        else
                            manager.names.Enqueue(lines[i].Remove(0, 2));

                        //manager.names.Enqueue(lines[i].Remove(0, 2));
                    }
                    if (lines[i][1] == ':')
                    {
                        manager.dialogues.Enqueue(lines[i].Remove(0, 2));
                    }
                    
                }
            }
            i++;
        }

        //for(ind=1; ind < nOfChoices; nOfChoices;)

    }

    // public void StopChoice()
    // {
    // }

}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charNameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Canvas choiceCanvas;
    [SerializeField] public int attractionAttained;
    int choicesDone = 0;
    int animationsDone = 0;

    public Queue<string> names = new Queue<string>();
    public Queue<string> dialogues = new Queue<string>();
    //public Queue<string> choices = new Queue<string>();
    public bool finishedDialogue = false;

    // Start is called before the first frame update
    void Awake()
    {
        attractionAttained = 0;
    }

    private void Start()
    {
        if(choiceCanvas == null)
        {
            if(GameObject.Find("Choice Canvas") != null)
            {
                choiceCanvas = GameObject.Find("Choice Canvas").GetComponent<Canvas>();
            }
        }
        FindObjectOfType<TextAnalyzer>().AnalyzeText();
        StartDialogue();
    }

    public void StartDialogue()
    {
        //names.Clear();
        //dialogues.Clear();

        // foreach (string sentence in dialogue.sentences)
        // {
        //     dialogues.Enqueue(sentence);
        // }

        // foreach (string name in dialogue.nameDisplays)
        // {
        //     names.Enqueue(name);
        // }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("Enqueue");
        if(dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }
        string nextName = names.Dequeue();
        string nextSentence = dialogues.Dequeue();

        //Debug.Log(nextName);
        if(nextName[0] == '@')
        {
            FindObjectOfType<PictureHandler>().UpdatePortrait((int)Char.GetNumericValue(nextName[1]));
            nextName = names.Dequeue();
        }
        if (nextName == "Choice")
        {
            DisplayNextChoice();
            return;
        }
        if (nextName == "Animation")
        {
            DisplayNextAnimation();
            nextName = names.Dequeue();

            return;
        }

        charNameText.text = nextName;
        dialogueText.text = nextSentence;
    }

    public void DisplayNextChoice()
    {
        choicesDone++;
        string theChoice = "Decision " + choicesDone.ToString();

        choiceCanvas.transform.Find("Background Choice").GameObject().SetActive(true);
        choiceCanvas.transform.Find(theChoice).GameObject().SetActive(true);

    }
    public void DisplayNextAnimation()
    {
        //string theChoice = "Decision " + choicesDone.ToString();
        GameObject[] objectsWithAnimation = GameObject.FindGameObjectsWithTag("Animation");

        foreach (GameObject theObject in objectsWithAnimation)
        {
            List<string> states = new List<string>();
            foreach (AnimationState state in theObject.GetComponent<Animation>())
            {
                states.Add(state.name);
            }
            //Debug.Log(states[0]);
            //Debug.Log(states[1]);
            theObject.GetComponent<Animation>().Play(states[0]);
        }
        animationsDone++;
        //choiceCanvas.transform.Find("Background Choice").GameObject().SetActive(true);
        //choiceCanvas.transform.Find(theChoice).GameObject().SetActive(true);

    }


    public void EndDialogue()
    {
        string neutralNameScene = SceneManager.GetActiveScene().name;
        neutralNameScene = neutralNameScene.Replace("_Negative", "");
        neutralNameScene = neutralNameScene.Replace("_Positive", "");

        if (attractionAttained >= 2){
            GameSession.Global_Choices[neutralNameScene + "_Positive"] = true;
            Debug.Log(neutralNameScene + "_Positive");
        }
        else
        {
            GameSession.Global_Choices[neutralNameScene + "_Negative"] = true;
            Debug.Log(neutralNameScene + "_Negative");
        }

        GameSession.Global_Choices[neutralNameScene] = true;
        

        finishedDialogue = true;
        GameSession.NightsLeft--;
        SceneManager.LoadScene("House Map");

    }
}

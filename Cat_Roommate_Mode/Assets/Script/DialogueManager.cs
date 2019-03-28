using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    GameObject Room;
    GameObject GameManager;
    public GameObject Dialogue_Box;
    GameObject Dialogue;
    GameObject Arrow;
    public bool end = false;
    TextMeshProUGUI Dialogue_Current;
    //int Dialogues_count = 1;
    int Dialogues_index = 0;

    List<string> DialogueList_Current;

    [SerializeField]
    [TextArea(3, 5)]
    public List<string> Dialogues1 = new List<string>();
    [SerializeField]
    [TextArea(3, 5)]
    public List<string> Dialogues2 = new List<string>();
    [SerializeField]
    [TextArea(3, 5)]
    public List<string> Dialogues3 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues4 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues5 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues6 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues7 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues8 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues9 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues10 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues11 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues12 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues13 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues14 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues15 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues16 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues17 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues18 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues19 = new List<string>();
    [TextArea(3, 5)]
    public List<string> Dialogues20 = new List<string>();
   



    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Arrow = GameObject.Find("Arrow");
        Room = GameObject.Find("Room");
        Dialogue_Box = GameObject.Find("Dialogue_Box");
        Dialogue = GameObject.Find("Dialogue");
        Dialogue_Current = Dialogue.GetComponent<TextMeshProUGUI>();
        DialogueList_Current = Dialogues1;
        Dialogue_Current.text = DialogueList_Current[Dialogues_index];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();

        }
    }

    void NextLine()
    {
        Dialogues_index++;
        if (Dialogues_index >= DialogueList_Current.Count)
        {
            if (end)
            {
                GameManager.SendMessage("EndGame");
                return;
            }
            GameManager.SendMessage("EndConversation");

        }
        else
        {
            switch (DialogueList_Current[Dialogues_index])
            {

                case "Q1":
                    GameManager.SendMessage("NextQuestion", 1);
                    break;

                case "Q2":
                    GameManager.SendMessage("NextQuestion", 2);
                    break;

                case "Q3":
                    GameManager.SendMessage("NextQuestion", 3);
                    break;

                case "Q4":
                    GameManager.SendMessage("NextQuestion", 4);
                    break;

                case "Q5":
                    GameManager.SendMessage("NextQuestion", 5);
                    break;

                case "Q6":
                    GameManager.SendMessage("NextQuestion", 6);
                    break;

                default:
                    Dialogue_Current.text = DialogueList_Current[Dialogues_index];
                    break;

            }
        }

    }



public void LoadDialogue(List<string> Dialogues)
    {
        Room.SetActive(false);
        Arrow.SetActive(false);
        DialogueList_Current = Dialogues;
        Dialogues_index = 0;
        Dialogue_Current.text = DialogueList_Current[Dialogues_index];

     }

 
}

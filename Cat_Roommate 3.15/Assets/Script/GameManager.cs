using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject Katio;
    GameObject Room;
    GameObject Arrow;
    GameObject Lost;
    GameObject Win;
    GameObject background;
    GameObject Question_Box;
    GameObject Question;
    GameObject Dialogue_Box;
    GameObject Dialogue;
    GameObject Answer_Left;
    GameObject Answer_Right;
    GameObject Button_Left;
    GameObject Button_Right;
    GameObject Button_Left_Image;
    GameObject Button_Right_Image;
    SpriteRenderer Katio_render;
    TextMeshProUGUI Question_current;
    TextMeshProUGUI Answer_Left_text;
    TextMeshProUGUI Answer_Right_text;
   
    public int status = 0;
    public int Wrong_count = 0;
    public int Right_count = 0;

    public int Question_index = 0;
    DialogueManager DialogueManager_Script;


    public Sprite cat1;
    public Sprite cat2;
    public Sprite cat3;
    public Sprite cat4;


    [SerializeField]
    [TextArea(3, 5)]
    List<string> Question_List = new List<string>();
    [SerializeField]
    List<string> RightAnswer_List = new List<string>();
    [SerializeField]
    List<string> LeftAnswer_List = new List<string>();

    void Start()
    {
        background = GameObject.Find("Background");
        Katio = GameObject.Find("Katio");
        Room = GameObject.Find("Room");
        Arrow = GameObject.Find("Arrow");
        Question = GameObject.Find("Question");
        Lost = GameObject.Find("Lost");
        Win = GameObject.Find("Win");
        Question_Box = GameObject.Find("Question_Box");
        Dialogue = GameObject.Find("Dialogue");
        Dialogue_Box = GameObject.Find("Dialogue_Box");
        DialogueManager_Script = Dialogue_Box.GetComponent<DialogueManager>();
        Answer_Left = GameObject.Find("Answer_Left");
        Answer_Right = GameObject.Find("Answer_Right");
        Button_Left = GameObject.Find("Button_Left");
        Button_Right = GameObject.Find("Button_Right");
        Button_Left_Image = GameObject.Find("Button_Left_Image");
        Button_Right_Image = GameObject.Find("Button_Right_Image");
       


        Answer_Left_text = Answer_Left.GetComponent<TextMeshProUGUI>();
        Answer_Right_text = Answer_Right.GetComponent<TextMeshProUGUI>();
        Katio_render = Katio.GetComponent<SpriteRenderer>();
        Question_current = Question.GetComponent<TextMeshProUGUI>();
        Question_current.text = Question_List[0];

        Question_current.text = Question_List[Question_index];
        float x = Random.Range(0.0f, 1.0f);
        if (x <= 0.5)
        {
            Answer_Left_text.text = RightAnswer_List[Question_index];
            Answer_Right_text.text = LeftAnswer_List[Question_index];
        }
        if (x > 0.5)
        {
            Answer_Left_text.text = LeftAnswer_List[Question_index];
            Answer_Right_text.text = RightAnswer_List[Question_index];
        }

        Question_Box.SetActive(false);
        Button_Left.SetActive(false);
        Button_Right.SetActive(false);
        Room.SetActive(false);
        Arrow.SetActive(false);
        Lost.SetActive(false);
        Win.SetActive(false);
    }



    public void GetAnswer(string answer)
    {
        Dialogue_Box.SetActive(true);
        Question_Box.SetActive(false);
        Button_Left.SetActive(false);
        Button_Right.SetActive(false);

        switch (answer)
        {
           
            case "About you":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues2);
                break;

            case "About this Apartment":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues3);
                break;

            case "Why?":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues5);
                RightAnswer();
                break;

            case "Good for you":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues6);
                WrongAnswer();
                break;

            case "What's wrong with you?":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues9);
                WrongAnswer();
                break;

            case "I respect that":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues8);
                RightAnswer();
                break;

            case "That's unfair":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues11);
                RightAnswer();
                break;

            case "Well...Maybe":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues12);
                WrongAnswer();
                break;

            case "I never cook":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues15);
                WrongAnswer();
                break;

            case "Love it":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues14);
                RightAnswer();
                break;

            case "I’m sorry":
                RightAnswer();
                if(Wrong_count<Right_count)
                {
                    Katio_render.sprite = cat2;
                    Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues17);
                }else
                {
                    Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues18);
                }
                DialogueManager_Script.end = true;
                break;

            case "Are you crazy?":
                WrongAnswer();
                if (Wrong_count < Right_count)
                {
                    Katio_render.sprite = cat2;
                    Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues19);
                }
                else
                {
                    Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues20);
                }
                DialogueManager_Script.end = true;
                break;
        }

        /*for (int i = 0; i < RightAnswer_List.Count; i++)
        {
            if(answer  == RightAnswer_List[i])
            {
                RightAnswer();
                DialogueGoesOn();
                return;
            }
        }

        WrongAnswer();
        DialogueGoesOn();*/
    }


    void RightAnswer()
    {
        Debug.Log("right");
        Right_count++;
        status++;
        checkStatus();

    }

    void WrongAnswer()
    {
        Debug.Log("wrong");
        Wrong_count++;
        status--;
        checkStatus();
    }

    void NextQuestion(int number)
    {
        Question_Box.SetActive(true);
        Button_Left.SetActive(true);
        Button_Right.SetActive(true);
        Dialogue_Box.SetActive(false);

        Question_index = number - 1;
        Question_current.text = Question_List[Question_index];
        Answer_Left_text.text = LeftAnswer_List[Question_index];
        Answer_Right_text.text = RightAnswer_List[Question_index];
           

    }

    void DialogueGoesOn()
    {
        Question_Box.SetActive(false);
        Button_Left.SetActive(false);
        Button_Right.SetActive(false);
        Dialogue_Box.SetActive(true);
    }

    void ObjectResponse(string obj)
    {
        Dialogue_Box.SetActive(true);
        Katio.SetActive(true);

        switch (obj)
        {

            case "Boxing":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues4);
                break;

            case "Curtain":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues7);
                break;

            case "TV":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues10);
                break;

            case "Knife":
                Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues13);
                break;
        }

    }

    void EndConversation()
    {
        if (Wrong_count + Right_count == 4)
        {
            Katio_render.sprite = cat3;
            Katio.transform.localScale = new Vector3(1.3f, 1.3f, 1);
            Dialogue_Box.SendMessage("LoadDialogue", DialogueManager_Script.Dialogues16);
            return;
        }
        Question_Box.SetActive(false);
        Button_Left.SetActive(false);
        Button_Right.SetActive(false);
        Dialogue_Box.SetActive(false);
        Katio.SetActive(false);
        Room.SetActive(true);
        Arrow.SetActive(true);
    }

    void EndGame()
    {
        Question_Box.SetActive(false);
        Button_Left.SetActive(false);
        Button_Right.SetActive(false);
        Dialogue_Box.SetActive(false);
        Katio.SetActive(false);
        Room.SetActive(false);
        Arrow.SetActive(false);
        background.SetActive(false);


        if (Wrong_count < Right_count)
        {
            Win.SetActive(true);
        }
        else
        {
            Lost.SetActive(true);
        }
    }

    void checkStatus()
    {
        if (status == 0)
            Katio_render.sprite = cat1;
        if (status == 2)
            Katio_render.sprite = cat4;
        if (status == -1)
            Katio_render.sprite = cat2;
     
    }

}

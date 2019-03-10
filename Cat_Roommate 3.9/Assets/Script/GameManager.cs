using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject Cat_Image;
    GameObject Question;
    GameObject Answer_Left;
    GameObject Answer_Right;
    GameObject Button_Left;
    GameObject Button_Right;
    GameObject Button_Left_Image;
    GameObject Button_Right_Image;
    SpriteRenderer Cat_Image_render;
    TextMeshPro Question_current;
    TextMeshProUGUI Answer_Left_text;
    TextMeshProUGUI Answer_Right_text;
    public int status = 0;
    int Button_Selected = 0;
    int Wrong_count = 0;
    int Right_count = 0;

    public int Question_index = 0;

    public Sprite cat0;
    public Sprite cat1;
    public Sprite cat2;
    public Sprite cat3;
    public Sprite cat4;
    public Sprite cat5;
    public Sprite cat6;
    public Sprite cat7;
    public Sprite cat8;
    public Sprite cat9;
    public Sprite cat10;
    public Sprite cat11;


    [SerializeField]
    [TextArea(3, 5)]
    List<string> Question_List = new List<string>();
    [SerializeField]
    List<string> RightAnswer_List = new List<string>();
    [SerializeField]
    List<string> WrongAnswer_List = new List<string>();

    void Start()
    {
        Cat_Image = GameObject.Find("Cat_Image");
        Question = GameObject.Find("Question");
        Answer_Left = GameObject.Find("Text_Left");
        Answer_Right = GameObject.Find("Text_Right");
        Button_Left = GameObject.Find("Button_Left");
        Button_Right = GameObject.Find("Button_Right");
        Button_Left_Image = GameObject.Find("Button_Left_Image");
        Button_Right_Image = GameObject.Find("Button_Right_Image");
       


        Answer_Left_text = Answer_Left.GetComponent<TextMeshProUGUI>();
        Answer_Right_text = Answer_Right.GetComponent<TextMeshProUGUI>();
        Cat_Image_render = Cat_Image.GetComponent<SpriteRenderer>();
        Question_current = Question.GetComponent<TextMeshPro>();
        Question_current.text = Question_List[0];

        Question_current.text = Question_List[Question_index];
        float x = Random.Range(0.0f, 1.0f);
        if (x <= 0.5)
        {
            Answer_Left_text.text = RightAnswer_List[Question_index];
            Answer_Right_text.text = WrongAnswer_List[Question_index];
        }
        if (x > 0.5)
        {
            Answer_Left_text.text = WrongAnswer_List[Question_index];
            Answer_Right_text.text = RightAnswer_List[Question_index];
        }
    }

   
    void Update()
    {
        if (Question_index <= Question_List.Count - 3)
        {
            if (Input.GetKey(KeyCode.RightArrow) && Button_Selected == 0)
            {
                Button_Selected = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Button_Selected == 1)
            {
                Button_Selected = 0;
            }

            if (Button_Selected == 0)
            {

                Button_Left.GetComponent<Image>().color = new Vector4(1, 0.8f, 0.4f, 1);
                Button_Right.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            }

            if (Button_Selected == 1)
            {

                Button_Right.GetComponent<Image>().color = new Vector4(1, 0.8f, 0.4f, 1);
                Button_Left.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            }

            if (Input.GetKeyUp(KeyCode.Return) && Button_Selected == 0)
            {
                Button_Left.SendMessage("sendAnswer");
            }

            if (Input.GetKeyUp(KeyCode.Return) && Button_Selected == 1)
            {
                Button_Right.SendMessage("sendAnswer");
            }

            //_________________________________________
           

        }

    }

    public void GetAnswer(string answer)
    {
        for (int i = 0; i < RightAnswer_List.Count; i++)
        {
            if(answer  == RightAnswer_List[i])
            {
                RightAnswer();
                return;
            }
        }

        WrongAnswer();
    }


    void RightAnswer()
    {
        Debug.Log("right");
        ChangeQuestion();
        Right_count++;
        status++;

    }

    void WrongAnswer()
    {
        Debug.Log("wrong");
        ChangeQuestion();
        Wrong_count++;
        status--;
    }


    void ChangeQuestion()
    {

        if (Question_index == 6 && Wrong_count < Right_count) 
        {
            Destroy(Button_Left);
            Destroy(Button_Right);
            Question_index = 7;
            Cat_Image_render.sprite = cat4;
            Question_current.text = Question_List[Question_index];
           
        }

        if (Question_index == 6 && Right_count < Wrong_count)
        {
            Destroy(Button_Left);
            Destroy(Button_Right);
            Question_index = 8;
            Cat_Image_render.sprite = cat8;
            Question_current.text = Question_List[Question_index];

        }

        if (Question_index < 6)
        {
            checkStatus();
            Question_index++;
            Question_current.text = Question_List[Question_index];
            float x = Random.Range(0.0f, 1.0f);
            if (x <= 0.5)
            {
                Answer_Left_text.text = RightAnswer_List[Question_index];
                Answer_Right_text.text = WrongAnswer_List[Question_index];
            }
            if (x > 0.5)
            {
                Answer_Left_text.text = WrongAnswer_List[Question_index];
                Answer_Right_text.text = RightAnswer_List[Question_index];
            }
        }

    }

    void checkStatus()
    {
        if (status == 0)
            Cat_Image_render.sprite = cat7;
        if (status == 1)
            Cat_Image_render.sprite = cat0;
        if (status == 2)
            Cat_Image_render.sprite = cat5;
        if (status == 3)
            Cat_Image_render.sprite = cat3;
        if (status == 4)
            Cat_Image_render.sprite = cat1;
        if (status == 5)
            Cat_Image_render.sprite = cat4;
        if (status == -1)
            Cat_Image_render.sprite = cat6;
        if (status == -2)
            Cat_Image_render.sprite = cat11;
        if (status == -3)
            Cat_Image_render.sprite = cat8;
        if (status == -4)
            Cat_Image_render.sprite = cat9;
        if (status == -3)
            Cat_Image_render.sprite = cat10;
    }

}

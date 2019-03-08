using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    GameObject Cat_Image;
    GameObject Question;
    GameObject Answer_Left;
    GameObject Answer_Right;
    SpriteRenderer Cat_Image_render;
    TextMeshPro Question_current;
    TextMeshProUGUI Answer_Left_text;
    TextMeshProUGUI Answer_Right_text;
    public int status = 0;

    int Question_index = 0;

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
        status++;

    }

    void WrongAnswer()
    {
        Debug.Log("wrong");
        ChangeQuestion();
        status--;
    }


    void ChangeQuestion()
    {
        Question_index++;
        Question_current.text = Question_List[Question_index];
        float x = Random.Range(0.0f, 1.0f);
        if(x <= 0.5)
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

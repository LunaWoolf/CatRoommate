using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject Answer;
    GameObject GameManager;
    GameObject Button_Left;
    GameObject Button_Right;
    //int Button_Selected = 0;
    public TextMeshProUGUI Answer_text;
    public string Current_Answer;
    Button Button_Left_script;
    Button Button_Right_script;
    ColorBlock Button_Left_Color;
    ColorBlock Button_Right_Color;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Button_Left = GameObject.Find("Button_Left");
        Button_Right = GameObject.Find("Button_Right");
        Button_Left_script = Button_Left.GetComponent<Button>();
        Button_Right_script = Button_Right.GetComponent<Button>();
        Button_Left_Color = Button_Left_script.colors;
        Button_Right_Color = Button_Right_script.colors;
        Answer_text = Answer.GetComponent<TextMeshProUGUI>();
        Current_Answer = Answer_text.text;
    }

    void Update()
    {

    }

    public void sendAnswer()
    {
        Current_Answer = Answer_text.text;
        GameManager.SendMessage("GetAnswer", Current_Answer);
    }
}

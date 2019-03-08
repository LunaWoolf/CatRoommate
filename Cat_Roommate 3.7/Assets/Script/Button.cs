using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject Answer;
    GameObject GameManager;
    public TextMeshProUGUI Answer_text;
    public string Current_Answer;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
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

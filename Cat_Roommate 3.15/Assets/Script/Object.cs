using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    GameObject GameManager;
    public string ThisObject;


    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }


    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameManager.SendMessage("ObjectResponse", ThisObject);
        Destroy(this.gameObject);
    }

    void OnMouseOver()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}

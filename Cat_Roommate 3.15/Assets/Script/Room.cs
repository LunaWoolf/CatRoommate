using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    GameObject background;
    float speed = 3f;
    
    void Start()
    {
        background = GameObject.Find("Background");
    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x < 8.5f)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            background.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x > -2)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            background.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}

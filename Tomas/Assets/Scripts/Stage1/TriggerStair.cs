using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStair : MonoBehaviour
{
    public Collider2D stair;

    bool isColliding = false;
    // Update is called once per frame
    void Update()
    {
        if(isColliding && Input.GetKeyDown(KeyCode.W))
            stair.isTrigger = false;
        else if(isColliding && Input.GetKeyDown(KeyCode.S))
            stair.isTrigger = true;
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController2D>() != null)
            isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
            isColliding = false;
    }
}

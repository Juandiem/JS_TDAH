using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public CursorGame cursorGame;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        moveInMainArea();        
    }

    void moveInMainArea()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        Vector3 pos = transform.position + new Vector3(x, y, 0);

        if (cursorGame.isInMainArea(pos))
            transform.Translate(x, y, 0);
        
    }
}

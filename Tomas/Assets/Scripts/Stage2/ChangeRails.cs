using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRails : MonoBehaviour
{
    public Transform left, leftCenter, center, right, rightCenter;
    public GameObject body;

    private int index = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(index>0)index--;
            Debug.Log("AAAAA");
            ChangeToIndexRail();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(index<4)index++;
            ChangeToIndexRail();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {

        }
    }

    private void ChangeToIndexRail()
    {
        switch (index)
        {
            case 0:
                body.transform.position=left.position;
                break;
            case 1:
                body.transform.position=leftCenter.position;
                break;
            case 2:
                body.transform.position=center.position;
                break;
            case 3:
                body.transform.position=rightCenter.position;
                break;
            case 4:
                body.transform.position=right.position;
                break;
        }
    }
}

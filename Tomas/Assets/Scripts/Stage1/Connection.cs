using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    Vector3 connection;

    public void setConnection(Vector3 pos)
    {
        connection = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController2D>() != null)
        {
            other.transform.position = connection;
        }
    }
}

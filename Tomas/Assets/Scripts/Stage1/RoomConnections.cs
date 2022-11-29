using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConnections : MonoBehaviour
{
    Vector3 pos;

    bool tpPlayer = false;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
            tpPlayer = true;
        else 
            tpPlayer = false;
    }

    public void setPostoTp(Vector3 p)
    {
        pos = p;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            sprite.enabled = true;
            if (tpPlayer)
            {
                collision.gameObject.transform.position = new Vector3(pos.x, pos.y, collision.gameObject.transform.position.z);
                Destroy(transform.parent.gameObject);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
            sprite.enabled = false;
    }
}

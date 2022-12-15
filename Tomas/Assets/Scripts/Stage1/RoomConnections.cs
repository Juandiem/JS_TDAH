using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConnections : MonoBehaviour
{
    Vector3 pos;

    bool tpPlayer = false;

    SpriteRenderer sprite;
    GameManager gameManager;

    GameObject playerEKey;

    private void Start()
    {
        gameManager = GameManager.instance;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        playerEKey = GameObject.Find("/Player/eKey");
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
            playerEKey.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.transform.position = new Vector3(pos.x, pos.y, collision.gameObject.transform.position.z);
                Destroy(transform.parent.gameObject.transform.parent.gameObject);
                gameManager.PlayerInHouse(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            sprite.enabled = false;
            playerEKey.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

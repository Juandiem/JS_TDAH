using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConnections : MonoBehaviour
{
    Vector3 pos;
    SpriteRenderer sprite;
    GameManager gameManager;

    GameObject playerEKey;

    bool entered = false;

    GameObject player;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered)
        {
            tpPlayer();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            sprite.enabled = true;
            player = collision.gameObject;
            playerEKey.GetComponent<SpriteRenderer>().enabled = true;
            entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            sprite.enabled = false;
            playerEKey.GetComponent<SpriteRenderer>().enabled = false;
            entered = false;
            player = null;
        }
    }

    void tpPlayer()
    {
        player.transform.position = new Vector3(pos.x, pos.y, player.transform.position.z);
        Destroy(transform.parent.gameObject.transform.parent.gameObject);
        gameManager.PlayerInHouse(true);
    }
}

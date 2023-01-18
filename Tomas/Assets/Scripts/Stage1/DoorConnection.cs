using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConnection : MonoBehaviour
{
    public GameObject preview;
    public GameObject room;
    public GameObject smoke;
    GameObject playerEKey;

    GameManager gameManager;

    public bool smokeActive = false;
    bool entered = false;

    GameObject player;

    private void Start()
    {
        gameManager = GameManager.instance;
        preview.SetActive(false);
        smoke.SetActive(false);
        playerEKey = GameObject.Find("/Player/eKey");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered)
            tpPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            player = collision.gameObject;
            playerEKey.GetComponent<SpriteRenderer>().enabled = true;
            
            entered = true;

            if(smokeActive) smoke.SetActive(true);
            preview.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            if (smokeActive) smoke.SetActive(false);
            preview.SetActive(false);
            playerEKey.GetComponent<SpriteRenderer>().enabled = false;
            entered = false;
            player = null;
        }
    }

    void tpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject gO = Instantiate(room);
            gO.transform.position = gameManager.getPlaceHolderRoomPos();
            gO.GetComponentInChildren<RoomConnections>().setPostoTp(this.gameObject.transform.position);
            Vector3 pos = new Vector3(gO.GetComponentInChildren<RoomSpawns>().getPos().x, gO.GetComponentInChildren<RoomSpawns>().getPos().y, player.transform.position.z);
            player.transform.position = pos;
            gameManager.PlayerInHouse(false);
            if (smokeActive)
            {
                smokeActive = false;
                smoke.SetActive(false);
            }

            gameManager.roomPlayer = room.tag;
        }
    }
}

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

    private void Start()
    {
        gameManager = GameManager.instance;
        preview.SetActive(false);
        smoke.SetActive(false);
        playerEKey = GameObject.Find("/Player/eKey");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerEKey.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject gO = Instantiate(room);
                gO.transform.position = gameManager.getPlaceHolderRoomPos();
                gO.GetComponentInChildren<RoomConnections>().setPostoTp(this.gameObject.transform.position);
                Vector3 pos = gO.GetComponentInChildren<RoomSpawns>().getPos();
                collision.gameObject.transform.position = new Vector3(pos.x, pos.y, collision.gameObject.transform.position.z);
                gameManager.PlayerInHouse(false);
                if (smokeActive) { 
                    smokeActive = false; 
                    smoke.SetActive(false); 
                }

                gameManager.roomPlayer = room.tag;
            }
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
        }
    }
}

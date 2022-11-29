using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorConnection : MonoBehaviour
{
    public GameObject preview;
    public GameObject room;
    GameManager gameManager;

    bool tpPlayer = false;

    private void Start()
    {
        gameManager = GameManager.instance;
        preview.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            tpPlayer = true;
        else
            tpPlayer = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            if (tpPlayer){
                GameObject gO = Instantiate(room);
                gO.transform.position = gameManager.getPlaceHolderRoomPos();
                gO.GetComponentInChildren<RoomConnections>().setPostoTp(this.gameObject.transform.position);
                Vector3 pos = gO.GetComponentInChildren<RoomSpawns>().getPos();
                collision.gameObject.transform.position = new Vector3(pos.x, pos.y, collision.gameObject.transform.position.z);
            }
            preview.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
            preview.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking.Types;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] roomsPrefabs;
    public GameObject[] roomPreviews;
    public Transform placeHolderRoom;
    public GameObject exitDoor;

    public Transform target, player;

    public Camera camera;

    bool requestedRandomize = false, startRandomize = false, endRandomize = false, startTimer = false;

    float timetoEnd = 2.0f, timePassedToEnd = 0.0f;
    float sizeCam;

    public bool isOnDialogue { get; set; }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sizeCam = camera.orthographicSize;
        isOnDialogue = false;
    }
    private void Update()
    {
        //Control de animacion
        if (startTimer)
        {
            timePassedToEnd += Time.deltaTime;
            endRandomize = true;
        }

        if (timePassedToEnd >= timetoEnd && startRandomize)
        {
            RandomizeRooms();
            EndedRandomizingAnimation();
            timePassedToEnd = 0.0f;
        }

        if (requestedRandomize)
        {
            camera.GetComponent<CameraFollow>().target = target;
            camera.orthographicSize = 1.8f*sizeCam;
            player.GetComponent<PlayerController2D>().allowMove = false;
        }
        else
        {
            if(roomPlayer == "house")
                camera.orthographicSize = sizeCam;
            else
                camera.orthographicSize = sizeCam*0.7f;
            camera.GetComponent<CameraFollow>().target = player;
            player.GetComponent<PlayerController2D>().allowMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (requestedRandomize)
        {
            if (startRandomize)
            {
                for (int i = 0; i < roomPreviews.Length; i++)
                {
                    Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, 0);
                    Vector3 smoothedPosition = Vector3.Lerp(roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.transform.position, desiredPosition, 0.05f);
                    roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.transform.position = smoothedPosition;
                }
                startTimer = true;

            }
            else if (endRandomize)
            {
                for (int i = 0; i < roomPreviews.Length; i++)
                {
                    Vector3 desiredPosition =
                        new Vector3(roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.transform.position.x,
                        roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.transform.position.y,
                        roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().smoke.transform.position.z
                        );
                    Vector3 smoothedPosition = Vector3.Lerp(roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.transform.position, desiredPosition, 0.05f);
                    roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.transform.position = smoothedPosition;
                }
                //Comprobamos que han llegado a su sitio
                Vector3 pos =
                    new Vector3((float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().preview.transform.position.x, 1),
                        (float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().preview.transform.position.y, 1),
                        (float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().smoke.transform.position.z, 1)
                        );
                Vector3 lastRoom =
                    new Vector3((float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().smoke.transform.position.x, 1),
                        (float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().smoke.transform.position.y, 1),
                        (float)Math.Round(roomPreviews[roomPreviews.Length - 1].GetComponentInChildren<DoorConnection>().smoke.transform.position.z, 1)
                        );
                if (lastRoom == pos)
                {
                    endRandomize = false;
                    startTimer = false;
                    requestedRandomize = false;
                    //Mostrar las vistas
                    for (int i = 0; i < roomPreviews.Length; i++)
                    {
                        roomPreviews[i].GetComponentInChildren<DoorConnection>().smokeActive = true;
                        roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.SetActive(false);
                    }
                }
            }


        }
    }

    public Vector3 getPlaceHolderRoomPos()
    {
        return placeHolderRoom.transform.position;
    }

    public void EnableMainDoor()
    {
       exitDoor.SetActive(true);
    }

    public void StartRandomizing() {
        //Ocultar las vistas
        for (int i = 0; i < roomPreviews.Length; i++)
        {
            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.SetActive(false);
            roomPreviews[i].GetComponentInChildren<DoorConnection>().smoke.SetActive(true);
        }

        //Hacer la animacion
        requestedRandomize = true;
        startRandomize = true;
    }

    private void EndedRandomizingAnimation()
    {
        startRandomize = false;
        endRandomize = true;

    }

    private void RandomizeRooms()
    {
        int[] instances= new int[roomPreviews.Length];
        for (int i = 0; i < instances.Length; i++)
            instances[i] = i;

        for(int i = 0; i < roomPreviews.Length; i++)
        {
            //Cambio de las conexiones de las preview de las salas
            int iRand = UnityEngine.Random.Range(0, instances.Length);
            int rand = instances[iRand];
            while(roomPreviews[rand].GetComponentInChildren<DoorConnection>().room == roomPreviews[i].GetComponentInChildren<DoorConnection>().room)
            {
                iRand = UnityEngine.Random.Range(0, instances.Length);
                rand = instances[iRand];
            }
            //Habitacion conectada
            GameObject tempGO = roomPreviews[rand].GetComponentInChildren<DoorConnection>().room;
            roomPreviews[rand].GetComponentInChildren<DoorConnection>().room = roomPreviews[i].GetComponentInChildren<DoorConnection>().room;
            roomPreviews[i].GetComponentInChildren<DoorConnection>().room = tempGO;

            //Cambio de preview a mostrar y actualizar posicion
            Sprite tempSprite = roomPreviews[rand].GetComponentInChildren<DoorConnection>().preview.GetComponent<SpriteRenderer>().sprite;
            roomPreviews[rand].GetComponentInChildren<DoorConnection>().preview.GetComponent<SpriteRenderer>().sprite = roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.GetComponent<SpriteRenderer>().sprite;
            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.GetComponent<SpriteRenderer>().sprite = tempSprite;

            //eliminamos el index para evitar posibles repeticiones
            if (instances.Length >= 0)
            {
                for (int j = iRand; i < instances.Length - 1; i++)
                {
                    instances[i] = instances[i + 1];
                }
                Array.Resize(ref instances, instances.Length - 1);
            }
        }
    }

    public void PlayerInHouse(bool state)
    {
        camera.GetComponent<CameraFollow>().cameraInHouse(state);
        if(state)roomPlayer = "house";
    }

    public string roomPlayer = "house";

}

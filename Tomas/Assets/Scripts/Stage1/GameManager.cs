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
    public GameObject exitDoor, clothes;
    public Animation startRandomRooms, endRandomRooms;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            clothes.SetActive(true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            RandomizeRooms();
            //StartRandomizing
        }
        //Control de animacion
        //if()...
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
        for(int i = 0;i<roomPreviews.Length;i++)
            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.SetActive(false);

        //Hacer la animacion

    }

    private void EndedRandomizingAnimation()
    {
        //Mostrar las vistas
        for (int i = 0; i < roomPreviews.Length; i++)
            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.SetActive(true);
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
            tempGO = roomPreviews[rand].GetComponentInChildren<DoorConnection>().preview;
            roomPreviews[rand].GetComponentInChildren<DoorConnection>().preview = roomPreviews[i].GetComponentInChildren<DoorConnection>().preview;
            roomPreviews[rand].GetComponentInChildren<DoorConnection>().preview.transform.position = roomPreviews[rand].transform.position;

            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview = tempGO;
            roomPreviews[i].GetComponentInChildren<DoorConnection>().preview.transform.position = roomPreviews[i].transform.position;

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
}

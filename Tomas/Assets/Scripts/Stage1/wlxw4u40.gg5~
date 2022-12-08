using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] roomsPrefabs;
    public GameObject[] roomPreviews;
    public Transform placeHolderRoom;
    public GameObject exitDoor, clothes;

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
    }

    public Vector3 getPlaceHolderRoomPos()
    {
        return placeHolderRoom.transform.position;
    }

    public void EnableMainDoor()
    {
       exitDoor.SetActive(true);
    }
}

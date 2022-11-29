using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawns : MonoBehaviour
{
    public Transform spawn;

    public Vector3 getPos()
    {
        return spawn.position;
    }
}

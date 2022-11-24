using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConnections : MonoBehaviour
{
    public GameObject triggerL, triggerR;

    public void setSpawnPoints(Vector3 posL, Vector3 posR)
    {
        triggerL.GetComponent<Connection>().setConnection(posL);
        triggerR.GetComponent<Connection>().setConnection(posR);
    }
}

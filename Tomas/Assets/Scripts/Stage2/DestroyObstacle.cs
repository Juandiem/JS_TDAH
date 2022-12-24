using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MoveObstacle>()) Destroy(other.gameObject);
        else if (other.gameObject.GetComponent<MoveBullet>()) Destroy(other.gameObject);
    }
}

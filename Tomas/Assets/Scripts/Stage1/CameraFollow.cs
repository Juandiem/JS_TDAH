using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.025f;
    public Vector3 offset;

    public float leftHouseLimit, rightHouseLimit, topHouseLimit, bottomHouseLimit;
    public float leftRoomLimit, rightRoomLimit, topRoomLimit, bottomRoomLimit;

    float leftLimit, rightLimit, topLimit, bottomLimit;

    bool isInHouse = true;

    float cameraSize;

    private void Start()
    {
        cameraSize = GetComponent<Camera>().orthographicSize;
        checkLimits();        
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }

    void checkLimits()
    {
        if (isInHouse)
        {
            leftLimit = leftHouseLimit;
            rightLimit = rightHouseLimit;
            topLimit = topHouseLimit;
            bottomLimit = bottomHouseLimit;
        }
        else
        {
            leftLimit = leftRoomLimit;
            rightLimit = rightRoomLimit;
            topLimit = topRoomLimit;
            bottomLimit = bottomRoomLimit;
        }
    }

    public void instantFollowPlayer()
    {
        transform.position = target.position + offset;
    }

    public void cameraInHouse(bool state)
    {
        isInHouse = state;
        instantFollowPlayer();
        checkLimits();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //House
        Gizmos.DrawLine(new Vector2(leftHouseLimit, topHouseLimit), new Vector2(rightHouseLimit, topHouseLimit));
        Gizmos.DrawLine(new Vector2(rightHouseLimit, topHouseLimit), new Vector2(rightHouseLimit, bottomHouseLimit));
        Gizmos.DrawLine(new Vector2(rightHouseLimit, bottomHouseLimit), new Vector2(leftHouseLimit, bottomHouseLimit));
        Gizmos.DrawLine(new Vector2(leftHouseLimit, bottomHouseLimit), new Vector2(leftHouseLimit, topHouseLimit));

        Gizmos.color = Color.red;
        //Room
        Gizmos.DrawLine(new Vector2(leftRoomLimit, topRoomLimit), new Vector2(rightRoomLimit, topRoomLimit));
        Gizmos.DrawLine(new Vector2(rightRoomLimit, topRoomLimit), new Vector2(rightRoomLimit, bottomRoomLimit));
        Gizmos.DrawLine(new Vector2(rightRoomLimit, bottomRoomLimit), new Vector2(leftRoomLimit, bottomRoomLimit));
        Gizmos.DrawLine(new Vector2(leftRoomLimit, bottomRoomLimit), new Vector2(leftRoomLimit, topRoomLimit));
    }


}

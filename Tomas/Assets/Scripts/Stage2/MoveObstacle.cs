using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 post;

    public float time;
    private float startingTime;

    private List<Vector3> posToMove;

    public float speedToMove;
    public float speed;

    private bool moved;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        startingTime = time;
        moved = true;
        rb.AddForce(new Vector3(0, 0, -speed * 100));
    }

    private void FixedUpdate()
    {
        if (time <= 0)
        {
            time = startingTime;
            if (posToMove != null && posToMove.Count >0 && post != posToMove[0])
            {
                Move(posToMove[0]);
                post = posToMove[0];
            }
        }
        else time-=Time.deltaTime;

        if(!moved)
        if (transform.position.x <= post.x + 0.1f && transform.position.x >= post.x - 0.1f)
        {
            if (transform.position.y <= post.y + 1.0f && transform.position.y >= post.y - 1.0f)
            {
                rb.velocity = new Vector3(0, 0, rb.velocity.z);
                posToMove.RemoveAt(0);
                moved = true;
            }
                
        }
    }

    private void Move(Vector3 pos)
    {
        if (transform.position != pos)
        {
            post = pos;
            rb.AddForce(new Vector3((pos.x - transform.position.x), 0, 0) * speedToMove * 10);
            moved = false;
        }
    }

    public void EnqueuePos(List<Vector3> pos)
    {
        posToMove = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 100 * speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MoveObstacle>())
        {


            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    public float time;
    private float startingTime;

    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            GameObject o = Instantiate(obstacle, transform);
            NormalWave(o);
            TwistWave(o);
            time = startingTime;
        }
        else time -= Time.deltaTime;
    }

    private void NormalWave(GameObject o)
    {
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                o.transform.localPosition = new Vector3(-10, 0, 0);
                break;
            case 1:
                o.transform.localPosition = new Vector3(-5, 0, 0);
                break;
            case 2:
                break;
            case 3:
                o.transform.localPosition = new Vector3(5, 0, 0);
                break;
            case 4:
                o.transform.localPosition = new Vector3(10, 0, 0);
                break;
        }
        o.GetComponent<MoveObstacle>().speed = 5;
    }

    private void TwistWave(GameObject o)
    {
        List<Vector3> l = new List<Vector3>();
        int i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                l.Add(new Vector3(-10, 0, 0));
                break;
            case 1:
                l.Add(new Vector3(-5, 0, 0));
                break;
            case 2:
                l.Add(new Vector3(0, 0, 0));
                break;
            case 3:
                l.Add(new Vector3(5, 0, 0));
                break;
            case 4:
                l.Add(new Vector3(10, 0, 0));
                break;
        }
        o.GetComponent<MoveObstacle>().EnqueuePos(l);
        o.GetComponent<MoveObstacle>().time = 1;
        o.GetComponent<MoveObstacle>().speedToMove = 5;
    }
}

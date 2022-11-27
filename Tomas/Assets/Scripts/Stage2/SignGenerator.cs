using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignGenerator : MonoBehaviour
{
    public GameObject sign;

    public float time;
    private float startingTime;

    public int iterations;

    public float signSpeed;

    public Material good, bad;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            if (iterations < 0) SceneManager.LoadScene(2);
            GameObject s = Instantiate(sign, transform);
            if (iterations == 0) s.GetComponent<SignScale>().changeTypeSign(good,true);
            else s.GetComponent<SignScale>().changeTypeSign(bad,false);
            s.GetComponent<Rigidbody>().AddForce(new Vector3(0, signSpeed * 10, 0));
            iterations--;
            time = startingTime;
        }
        else time -= Time.deltaTime;
    }
}

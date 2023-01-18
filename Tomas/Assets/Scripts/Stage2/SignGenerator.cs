using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class SignGenerator : MonoBehaviour
{
    public GameObject sign;

    public float time;
    private float startingTime;

    public int iterations;

    public float signSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startingTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.startGame)
        {
            if (time < 0)
            {
                if (iterations < -1) SceneManager.LoadScene(2);
                GameObject s = Instantiate(sign, transform);
                if (iterations == 0)
                {
                    s.GetComponent<SignScale>().SetGlovesColor(Color.red);
                    s.GetComponent<SignScale>().SetText("Kwal");
                    s.GetComponent<SignScale>().SetGoodSign(true);
                }
                else
                {
                    Color[] colores = { Color.red, Color.blue, Color.cyan, Color.gray, Color.green, Color.white, Color.yellow, Color.magenta };
                    string[] nombres = { "Kwol", "Kawl", "Kwl", "Klal", "Klaw", "Kwel", "Kval", "Kvval" };

                    s.GetComponent<SignScale>().SetGlovesColor(colores[UnityEngine.Random.Range(0, colores.Length)]);
                    s.GetComponent<SignScale>().SetText(nombres[UnityEngine.Random.Range(0, nombres.Length)]);
                }
                s.GetComponent<Rigidbody>().AddForce(new Vector3(0, signSpeed * 10, 0));
                iterations--;
                time = startingTime;
            }
            else time -= Time.deltaTime;
        }
    }
}

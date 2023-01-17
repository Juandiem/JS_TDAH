using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignScale : MonoBehaviour
{
    public GameObject gloves;
    public GameObject text;

    public float time;
    private float startingTime;

    public float deathTime;

    private bool good;

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
            transform.localScale = transform.localScale * 1.05f;
            transform.position =transform.position + new Vector3(0.5f,0,0);
            time = startingTime;
        }
        else time -= Time.deltaTime;

        if(good && Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(3);
        }

        if (deathTime < 0) Destroy(gameObject);
        else deathTime -= Time.deltaTime;
    }

    public void SetGoodSign(bool b)
    {
        good = b;
    }

    public void SetGlovesColor(Color c)
    {
        gloves.GetComponent<SpriteRenderer>().color = c;
    }

    public void SetText(string s)
    {
        text.GetComponent<TextMesh>().text = s;
    }
}

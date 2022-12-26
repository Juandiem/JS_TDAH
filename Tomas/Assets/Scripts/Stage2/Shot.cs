using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;

    public float bulletSpeed;

    public float timer;
    private float startingTimer;

    private void Start()
    {
        startingTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(bullet, transform);
            go.GetComponent<MoveBullet>().speed = bulletSpeed;
            transform.DetachChildren();
            timer = startingTimer;
        }
    }
}

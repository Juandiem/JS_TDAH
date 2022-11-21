using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTurn : MonoBehaviour
{
    public GameObject blurr;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
            blurr.SetActive(false);
        else
            blurr.SetActive(true);
    }
}

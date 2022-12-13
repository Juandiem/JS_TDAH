using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public int lives;
    public GameObject[] hearts;

    private void Update()
    {
        if(lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveObstacle>())
        {
            lives--;
            hearts[lives].SetActive(false);
        }
    }
}

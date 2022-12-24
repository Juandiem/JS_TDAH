using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject text;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int i)
    {
        score += i;
        text.GetComponent<TextMesh>().text = score.ToString();
    }
}

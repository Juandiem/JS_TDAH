using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethQuest : Quest
{
    GameObject toothbrush;

    public TeethQuest(GameObject gO)
    {
        this.toothbrush = gO;
        Start();
    }

    void Start()
    {
        Debug.Log("toothbrush assigned");
        title = "Lavate los dientes";
        description = "Ve al baño y lavate los dientes";

        goals.Add(new InteractWithGoal(toothbrush, "Cepillate los dientes", false, 0, 1));

        toothbrush.SetActive(true);
    }
}

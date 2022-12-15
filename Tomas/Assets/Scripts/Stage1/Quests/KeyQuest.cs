using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyQuest : Quest
{
    GameObject key;

    public KeyQuest(GameObject gO)
    {
        this.key = gO;
        Start();
    }

    void Start()
    {
        Debug.Log("toothbrush assigned");
        title = "Busca la llave";
        description = "Busca la llave perdida";

        goals.Add(new InteractWithGoal(key, "Encuentra la llave", false, 0, 1));

        key.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesQuest : Quest
{
    GameObject clothes;
    public ClothesQuest(GameObject gO)
    {
        this.clothes = gO;
        Start();
    }

    void Start()
    {
        Debug.Log("Clothes assigned");
        title = "Vistete";
        description = "Vuelve a tu habitacion y cambiate";

        goals.Add(new InteractWithGoal(clothes, "Ponte el abrigo", false, 0, 1));
        goals.Add(new TalkToMomGoal("Habla con mamá", false, 0, 1));


        clothes.SetActive(true);
    }
}

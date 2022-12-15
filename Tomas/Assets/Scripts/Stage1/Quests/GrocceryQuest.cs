using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrocceryQuest : Quest
{
     GameObject grocery;

    public GrocceryQuest(GameObject gO)
    {
        this.grocery = gO;
        Start();
    }
    void Start()
    {
        Debug.Log("Groccery assigned");
        title = "Recoge la compra";
        description = "Ve al garaje y lleva la compra a la cocina";

        goals.Add(new InteractWithGoal(grocery, "Recoge la compra", false, 0, 1));
        goals.Add(new TalkToMomGoal("Habla con mamá", false, 0, 1));

        grocery.SetActive(true);
    }
}

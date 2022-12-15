using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialQuest : Quest
{
    public InitialQuest()
    {
        Start();
    }

    void Start()
    {
        Debug.Log("Mom assigned");
        title = "Habla con mamá";
        description = "Mamá está esperándote en la cocina";

        goals.Add(new TalkToMomGoal("Habla con mamá", false, 0, 1));

    }
}

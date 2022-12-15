using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithGoal : QuestGoal
{
    public GameObject goalGo;

    public InteractWithGoal(GameObject gO, string description, bool completed, int currentAmount, int requiredAmount)
    {
        goalGo = gO;
        this.description = description;
        this.completed = completed;
        this.currenAmount = currentAmount;
        this.requiredAmount = requiredAmount;
    }
    public override void Init()
    {
        base.Init();
    }

    public void ObjectInteracted(GameObject go)
    {
        if (go == goalGo)
        {
            this.currenAmount++;
            Evaluate();
        }
    }



}

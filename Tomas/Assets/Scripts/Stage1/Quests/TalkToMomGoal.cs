using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToMomGoal : QuestGoal
{
    public TalkToMomGoal(string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.description = description;
        this.completed = completed;
        this.currenAmount = currentAmount;
        this.requiredAmount = requiredAmount;
    }
    public override void Init()
    {
        base.Init();
    }

    public void momTalked()
    {
        this.currenAmount++;
        Evaluate();
    }

}

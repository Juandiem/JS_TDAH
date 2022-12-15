using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public string description { get; set; }
    public bool completed { get; set; }
    public int currenAmount { get; set; }
    public int requiredAmount { get; set; }

    public virtual void Init()
    {

    }

    public void Evaluate()
    {
        if (currenAmount >= requiredAmount)
            Complete();
    }

    public void Complete()
    {
        completed = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public List<QuestGoal> goals = new List<QuestGoal>();  
    public bool isActive;

    public string title;
    public string description;

    public bool completed;

    public void CheckGoals()
    {
        int i = 0;
        while (i < goals.Count && goals[i].completed) i++;
        if (i < goals.Count)
            completed = false;
        else
            completed = true;
    }
}

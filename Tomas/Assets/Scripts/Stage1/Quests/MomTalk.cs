using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomTalk : MonoBehaviour
{
    GameObject playerFKey;

    private void Start()
    {
        playerFKey = GameObject.Find("/Player/fKey");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerFKey.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                int i = 0;
                while (i < collision.GetComponent<QuestGiver>().currentQuest.goals.Count
                    && collision.GetComponent<QuestGiver>().currentQuest.goals[i].completed) i++;
                if (i == collision.GetComponent<QuestGiver>().currentQuest.goals.Count - 1)
                {
                    TalkToMomGoal g = collision.GetComponent<QuestGiver>().currentQuest.goals[i] as TalkToMomGoal;
                    g.momTalked();
                    Debug.Log("Mom Talked");
                    playerFKey.GetComponent<SpriteRenderer>().enabled = false;
                    collision.GetComponent<DialogueTrigger>().TriggerDialogue();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerFKey.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

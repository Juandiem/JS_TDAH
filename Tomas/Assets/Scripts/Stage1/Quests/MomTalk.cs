using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomTalk : MonoBehaviour
{
    GameObject playerFKey, player;

    bool entered = false;

    private void Start()
    {
        playerFKey = GameObject.Find("/Player/fKey");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && entered)
        {
            doTalk();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerFKey.GetComponent<SpriteRenderer>().enabled = true;
            player = collision.gameObject;
            entered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerFKey.GetComponent<SpriteRenderer>().enabled = false;
            entered = false;
            player = null;
        }
    }

    void doTalk()
    {
        int i = 0;
        while (i < player.GetComponent<QuestGiver>().currentQuest.goals.Count
            && player.GetComponent<QuestGiver>().currentQuest.goals[i].completed) i++;
        if (i == player.GetComponent<QuestGiver>().currentQuest.goals.Count - 1)
        {
            TalkToMomGoal g = player.GetComponent<QuestGiver>().currentQuest.goals[i] as TalkToMomGoal;
            g.momTalked();
            Debug.Log("Mom Talked");
            playerFKey.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}

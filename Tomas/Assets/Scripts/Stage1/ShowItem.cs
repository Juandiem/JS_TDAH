using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    GameManager gameManager;
    GameObject playerFKey;

    public string roomTag;

    private void Start()
    {
        gameManager = GameManager.instance;
        playerFKey = GameObject.Find("/Player/fKey");
    }

    private void Update()
    {
        if (roomTag == gameManager.roomPlayer)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
        {
            playerFKey.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerFKey.GetComponent<SpriteRenderer>().enabled = false;
                if (!collision.GetComponent<QuestGiver>().currentQuest.goals[0].completed)
                {
                    InteractWithGoal g = collision.GetComponent<QuestGiver>().currentQuest.goals[0] as InteractWithGoal;
                    g.ObjectInteracted(this.gameObject);
                    Debug.Log("Item Picked");
                    if (this.tag == "clothes")
                    {
                        collision.GetComponent<PlayerController2D>().changeStreet();
                        DialogueTrigger dialoguePlayer = collision.GetComponent<DialogueTrigger>();
                        dialoguePlayer.TriggerDialogue();
                        dialoguePlayer.dialogue.sentences.Clear();
                        dialoguePlayer.dialogue.name = "MAMÁ";
                        dialoguePlayer.dialogue.sentences.Add("Veo que ya estás listo, ¿no te habrás olvidado de lavarte los dientes, no?");
                        dialoguePlayer.dialogue.sentences.Add("...");
                        dialoguePlayer.dialogue.sentences.Add("...");
                        dialoguePlayer.dialogue.sentences.Add("Sí parece que sí. Hijo verás necesito que te lleves contigo el móvil para decirte donde tienes que ir.");
                        dialoguePlayer.dialogue.sentences.Add("Creo que tu móvil lo había guardado en la oficina, en el cajón con llave, lo único que no la encuentro...");
                        dialoguePlayer.dialogue.sentences.Add("Sé un cielo, y mira a ver si la encuentras.");
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController2D>() != null)
            playerFKey.GetComponent<SpriteRenderer>().enabled = false;
    }
}

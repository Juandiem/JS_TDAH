using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public GameObject[] questObjects;

    public Quest currentQuest;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;

    int phase = -2;

    bool randomize = false;

    DialogueTrigger dialoguePlayer;

    private void Start()
    {
        dialoguePlayer = GetComponent<DialogueTrigger>();
        dialoguePlayer.dialogue.sentences.Clear();
        dialoguePlayer.dialogue.name = "MAMÁ";
        dialoguePlayer.dialogue.sentences.Add("¡¡¡¡¡TIMMY, CARIÑOOOO!!!!!!");
        dialoguePlayer.dialogue.sentences.Add("¡Puedes venir a la cocina un momento, hijo!");
        dialoguePlayer.dialogue.sentences.Add("¡Necesito ayuda con una cosa!");
    }

    public void OpenQuestWindow()
    {
        titleText.text = currentQuest.title;
        descriptionText.text = currentQuest.description;
    }

    public void AcceptQuest()
    {
        switch (phase)
        {
            case -1:
                dialoguePlayer.dialogue.sentences.Clear();
                dialoguePlayer.dialogue.name = "MAMÁ";
                dialoguePlayer.dialogue.sentences.Add("Hola hijo, que bien que has aparecido, veras hoy he tenido que hacer muchas cosas y con las prisas me " +
                    "he dejado la compra en el garaje.");
                dialoguePlayer.dialogue.sentences.Add("Estoy esperando una llamada importante, así que traemela aquí. Hazme el favor.");
                dialoguePlayer.dialogue.sentences.Add("Y date prisa que seguro que los helados se están derritiendo y ya te conozco.");
                currentQuest = new InitialQuest();
                OpenQuestWindow();
                break;
            case 0:
                dialoguePlayer.dialogue.sentences.Clear();
                dialoguePlayer.dialogue.name = "MAMÁ";
                dialoguePlayer.dialogue.sentences.Add("Muchas gracias, déjalo en la encimera.");
                dialoguePlayer.dialogue.sentences.Add("A ver...");
                dialoguePlayer.dialogue.sentences.Add("¡Que cabeza la mía! Se me ha olvidado traer pan.");
                dialoguePlayer.dialogue.sentences.Add("Y encima la panadería de al lado está cerrada... También se está haciendo tarde...");
                dialoguePlayer.dialogue.sentences.Add("No me da tiempo a hacer la comida e ir a por el pan... Hijo, ¿puedes hacerme el favor de ir tu a por un par " +
                    "de barras de pan?");
                dialoguePlayer.dialogue.sentences.Add("Sé que está algo lejos pero si te vas ahora, llegarás a tiempo.");
                dialoguePlayer.dialogue.sentences.Add("Rápido, sube a lavarte los dientes y cambiate... ¡Ah! Y ponte algo de abrigo que hace algo de frío");
                dialoguePlayer.dialogue.sentences.Add("Cuando termines de cambiarte baja de nuevo a verme.");
                currentQuest = new GrocceryQuest(questObjects[0]);
                OpenQuestWindow();
                break;
            case 1:
                currentQuest = new TeethQuest(questObjects[1]);
                randomize = true;
                OpenQuestWindow();
                break;
            case 2:
                dialoguePlayer.dialogue.sentences.Clear();
                dialoguePlayer.dialogue.name = "TIMMY";
                dialoguePlayer.dialogue.sentences.Add("Vale... Ya estoy listo, voy a ver que quiere mamá");
                currentQuest = new ClothesQuest(questObjects[2]);
                randomize = true;
                OpenQuestWindow();
                break;
            case 3:
                currentQuest = new KeyQuest(questObjects[3]);
                randomize = true;
                OpenQuestWindow();
                break;
            case 4:
                dialoguePlayer.dialogue.sentences.Clear();
                dialoguePlayer.dialogue.name = "MAMÁ";
                dialoguePlayer.dialogue.sentences.Add("Que bien hijo, lo has encontrado. Dámelo un momento.");
                dialoguePlayer.dialogue.sentences.Add("...");
                dialoguePlayer.dialogue.sentences.Add("...");
                dialoguePlayer.dialogue.sentences.Add("...");
                dialoguePlayer.dialogue.sentences.Add("Perfecto, ya te he puesto los buses que puedes usar para ir, llevatelo por si te pierdes y necesitas llamarme");
                dialoguePlayer.dialogue.sentences.Add("Cuidate mucho hijo. Te quiero.");
                currentQuest = new CellPhoneQuest(questObjects[4]);
                randomize = true;
                OpenQuestWindow();
                break;
            case 5:
                GameManager.instance.EnableMainDoor();
                titleText.text = "Compra el pan";
                descriptionText.text = "Ya estas listo, sal por la puerta principal";
                break;
        }
        currentQuest.isActive = true;
    }

    public void checkEndQuest()
    {
        if (currentQuest != null)
        {
            currentQuest.CheckGoals();
            if (currentQuest.completed)
            {
                phase++;
                AcceptQuest();
            }
        }
    }

    private void Update()
    {
        if (!LevelChanger.instance.fadeInCompleted)
        {
            dialoguePlayer.TriggerDialogue();
        }
        else
        {
            if (randomize && GameManager.instance.roomPlayer == "house")
            {
                GameManager.instance.StartRandomizing();
                randomize = false;
            }

            if (phase > -2)
                checkEndQuest();
            else
            {
                if (!GameManager.instance.isOnDialogue)
                {
                    phase++;
                    AcceptQuest();
                    OpenQuestWindow();
                }

            }
        }
    }
}
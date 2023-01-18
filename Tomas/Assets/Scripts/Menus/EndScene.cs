using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public DialogueManager dialogueManager;
    DialogueTrigger dialoguePlayer;
    public AudioClip song;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.setAudioClip(song);
        MusicManager.instance.play();
        dialoguePlayer = GetComponent<DialogueTrigger>();
        dialoguePlayer.dialogue.sentences.Clear();
        dialoguePlayer.dialogue.name = "MAMÁ";
        dialoguePlayer.dialogue.sentences.Add("Ay cariño, me tenías preocupada. Te estaba llamando y no lo cogías...");
        dialoguePlayer.dialogue.sentences.Add("Gracias por hacerme este recado, más sabiendo lo duro que debe haber sido para ti");
        dialoguePlayer.dialogue.sentences.Add("En cuanto a la llamada del médico, me ha recetado una medicina que te tienes que tomar por tu bien");
        dialoguePlayer.dialogue.sentences.Add("No te preocupes, no es nada grave pero es por si acaso lo necesitas");
        dialoguePlayer.dialogue.sentences.Add("Bueno, voy a terminar la comida, tu si quieres vete al salón a descansar");
        dialoguePlayer.dialogue.sentences.Add("¡Ah! Una última cosa...");
        dialoguePlayer.dialogue.sentences.Add("¿Qué te apetece comer...");
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelChanger.instance.fadeInCompleted)
        {
            dialoguePlayer.TriggerDialogue();
        }
        else
        {
            if (!dialogueManager.isOnDialogue)
            {
                LevelChanger.instance.FadeToLevel(0);
            }
        }
    }
}

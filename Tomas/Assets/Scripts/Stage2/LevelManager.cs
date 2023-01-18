using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public AudioClip song;

    public bool startGame { get; set; }

    DialogueTrigger dialoguePlayer;
    public DialogueManager dialogueManager;
    public GameObject options;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        MusicManager.instance.setAudioClip(song);
        MusicManager.instance.play();
        dialoguePlayer = GetComponent<DialogueTrigger>();
        dialoguePlayer.dialogue.sentences.Clear();
        dialoguePlayer.dialogue.name = "MAMÁ";
        dialoguePlayer.dialogue.sentences.Add("**Ring** **Ring** **Ring**");
        dialoguePlayer.dialogue.sentences.Add("**Ring** **Ring** **Ring**");
        dialoguePlayer.dialogue.sentences.Add("**Ring** **Ring** **Ring**");
        dialoguePlayer.dialogue.sentences.Add("¡Hijo! ¿Me oyes?");
        dialoguePlayer.dialogue.sentences.Add("Ya estás en el autobus, ¿verdad?");
        dialoguePlayer.dialogue.sentences.Add("Bien entonces, seré rápida. La panadería está a unas cuantas paradas...");
        dialoguePlayer.dialogue.sentences.Add("¡Cachis! No me acuerdo del nombre de la parada, cariño");
        dialoguePlayer.dialogue.sentences.Add("Pero no te preocupes, sé que está al lado del cartel gigante ese de los guantes...");
        dialoguePlayer.dialogue.sentences.Add("Ay... Como se llamaban...");
        dialoguePlayer.dialogue.sentences.Add("¡KWAL! ¡KWAL, SE LLAMABAN!, ya sabes los de color azul...o eran rojos... Bueno sé que se llamaban KWAL");
        dialoguePlayer.dialogue.sentences.Add("Son fáciles de ver, pero no te pases de la parada, ten cuidado");
        dialoguePlayer.dialogue.sentences.Add("Bueno te dejo, que me llaman por la otra línea");
        dialoguePlayer.dialogue.sentences.Add("Si te pasa algo llamame");
        dialoguePlayer.dialogue.sentences.Add("Presiona la P cuando quieras BAJAR");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            options.SetActive(!options.activeSelf);
            Time.timeScale = (options.activeSelf) ? 0f : 1f;
        }

        if (!LevelChanger.instance.fadeInCompleted)
        {
            dialoguePlayer.TriggerDialogue();
        }
        else
        {
            if (!dialogueManager.isOnDialogue && !startGame)
            {
                startGame = true;
            }
        }
    }
}

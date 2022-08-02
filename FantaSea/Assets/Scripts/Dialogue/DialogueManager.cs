using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI textUI;
    public string name; //name of NPC;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI interactText;
    public bool isInteracting; //is a player nearby to talk to
    public bool typing;
    private int totalVisibleCharacters;
    private NPC currentNPC;
    private void Start() {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue, NPC n) {
        /*
         * HOW THIS WORKS...
         * First, we destroy the player object. 
         * Next, we turn on this NPC's camera.
         * The Dialogue Manager has access to its own player input. The reasoning is that it needs
         * to hold onto the controls for the dialogue. its easier to just destroy the player
         * and re-instantiate it later. 
         */
        currentNPC = n;
        SeaManager.instance.sea.ChangeTarget(n.gameObject);
        Destroy(FindObjectOfType<PlayerMovement>().gameObject);
        

        currentNPC.TurnOnCamera();

        this.GetComponent<PlayerInput>().enabled = true;

        this.name = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.lines) {
            sentences.Enqueue(sentence);
        }
        DisplaySentence();
    }

   
    public void ProceedContext(InputAction.CallbackContext context) {
        if(context.performed)DisplaySentence();
    }

    public void ExitContext(InputAction.CallbackContext context) {
        if (context.performed) EndDialogue();
    }

    /*private void Update() {
        if (isInteracting) {
            if (Input.GetKeyDown(KeyCode.E)) {
                if(!typing)
                    DisplaySentence();
                else {
                    StopAllCoroutines();
                    textUI.maxVisibleCharacters = totalVisibleCharacters;
                    typing = false;
                }
            }
        }
    }*/

    public void DisplaySentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        if(sentences.Count < 1) {
            interactText.text = "Press E to close!";
        } else {
            interactText.text = "Press E to progress!";
        }
        nameText.text = name.ToString();
        StopAllCoroutines();
        StartCoroutine(TypeWords(sentence));
    }

    public void EndDialogue() {
        this.GetComponent<PlayerInput>().enabled = false;

        GameManager.instance.SpawnPlayer(currentNPC.m_playerSpawn, currentNPC.gameObject.transform);

        currentNPC.TurnOffCamera();
        textUI.text = "";
        nameText.text = "";
        interactText.text = "";
        isInteracting = false;
        typing = false;
    }
    IEnumerator TypeWords(string line) {
        typing = true;
        textUI.text = line;
        textUI.ForceMeshUpdate();
        totalVisibleCharacters = textUI.textInfo.characterCount;
        int counter = 0;
        
        while (true) {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textUI.maxVisibleCharacters = visibleCount;

            if(visibleCount >= totalVisibleCharacters) {
                break;
            }
            counter++;
            yield return new WaitForSeconds(0.05f);
        }
        textUI.maxVisibleCharacters = totalVisibleCharacters;
        typing = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public TextMeshProUGUI textUI;
    public string name; //name of NPC;
    public TextMeshProUGUI nameText;
    public float timer;
    public float maxTimer = 3;
    public bool isTalking; //are you waiting for the next line
    public bool isInteracting; //is a player nearby to talk to
    private void Start() {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue) {
        this.name = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.lines) {
            sentences.Enqueue(sentence);
        }
        DisplaySentence();
    }

    private void Update() {
        if (isInteracting) {
            if (!isTalking) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    DisplaySentence();
                }
            }
        }
    }

    public void DisplaySentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        nameText.text = name.ToString();
        StopAllCoroutines();
        StartCoroutine(TypeWords(sentence));
        isTalking = true;
    }

    public void EndDialogue() {
        textUI.text = "";
        nameText.text = "";
        isTalking = false;
        isInteracting = false;
    }
    IEnumerator TypeWords(string line) {

        textUI.text = line;
        textUI.ForceMeshUpdate();
        int totalVisibleCharacters = textUI.textInfo.characterCount;
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
        timer = maxTimer;
        isTalking = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [Header("NPC Dialogue")]
    public Dialogue dialogue;
    public DialogueManager manager;

    
    public override void StartInteraction() {
        
        manager = FindObjectOfType<DialogueManager>();
        manager.isInteracting = true;
        manager.StartDialogue(dialogue);
    }

    public override void StopInteraction() {
        manager.EndDialogue();
    }

    
}

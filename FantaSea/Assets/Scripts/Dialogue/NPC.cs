using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [Header("NPC Dialogue")]
    public Dialogue dialogue;
    public DialogueManager manager;
    public Transform m_playerSpawn;

    [SerializeField] private Camera m_cam;
    public void TurnOnCamera() {
        m_cam.enabled = true;
    }

    public void TurnOffCamera() {
        m_cam.enabled = false;
    }
    
    
    public override void StartInteraction() {
        
        manager = FindObjectOfType<DialogueManager>();
        manager.isInteracting = true;
        manager.StartDialogue(dialogue, this);
    }

    public override void StopInteraction() {
        manager.EndDialogue();
    }

    
}

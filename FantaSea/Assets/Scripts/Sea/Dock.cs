using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Interactable
{
    /*
     * The dock needs to be able to change character controls, model, and position. 
     * ie: the boat lands in the dock, the player gets out and can now walk around. 
     */

    [SerializeField] private Transform m_playerSpawn;
    [SerializeField] private Transform m_boatSpawn;
    [SerializeField] private bool nearDeck;

    public override void StartInteraction() {
        Debug.Log("Interacted with Dock!");
        SwitchCharacters();
    }

    public override void StopInteraction() {


    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Boat") || other.gameObject.CompareTag("Player")) {
            nearDeck = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Boat") || other.gameObject.CompareTag("Player")) {
            nearDeck = false;
        }
    }

    private void SwitchCharacters() {
        
        GameManager.instance.SwitchCharacters(m_playerSpawn, m_boatSpawn);
    }

}

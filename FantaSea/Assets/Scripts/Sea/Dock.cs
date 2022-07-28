using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour
{
    /*
     * The dock needs to be able to change character controls, model, and position. 
     * ie: the boat lands in the dock, the player gets out and can now walk around. 
     */

    [SerializeField] private Transform m_playerSpawn;
    [SerializeField] private Transform m_boatSpawn;
    [SerializeField] private bool nearDeck;

    private void Update() {
        if (nearDeck) {
            if (Input.GetKeyDown(KeyCode.E)) {
                SwitchCharacters();
            }
        }
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
        PlayerMovement player = Instantiate(GameManager.instance.m_player, m_playerSpawn.position, Quaternion.identity);
        Destroy(FindObjectOfType<Boat_Base>().gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pedistal : MonoBehaviour
{

    public LettersManager manager;
    public Transform placement;
    public List<GameObject> milks = new List<GameObject>();
    
    private void Start() {
        manager = FindObjectOfType<LettersManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (manager.CheckIfDone()) {
                PlayerMovement player = FindObjectOfType<PlayerMovement>();
                player.canMove = false;
                player.gameObject.transform.position = placement.position;
                StartMilkEvent();
            }
        }
    }

    /// <summary>
    /// The Council of Milk decides your fate. 
    /// </summary>
    public void StartMilkEvent() {
        foreach(GameObject milk in milks) {
            milk.SetActive(true);
        }
        this.GetComponent<AudioSource>().Play();
    }

}

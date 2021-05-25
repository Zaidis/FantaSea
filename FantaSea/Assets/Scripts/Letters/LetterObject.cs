using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterObject : MonoBehaviour
{

    public int id;
    public LettersManager manager;
    private void Start() {
        manager = FindObjectOfType<LettersManager>();
    }
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Ow");
        if (collision.collider.gameObject.CompareTag("Player")) {
            Debug.Log("The player hit me!");
            manager.CheckID(id);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Ow");
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("The player hit me!");
            manager.CheckID(id);
            Destroy(this.gameObject);
        }
    }
}

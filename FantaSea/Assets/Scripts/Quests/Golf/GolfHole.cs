using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfHole : MonoBehaviour
{
    //you knock a ball in a gopher hole
    public GameObject letter;
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Pickup")) {
            if(collision.collider.gameObject.layer == 7) {
                letter.SetActive(true);
                Destroy(collision.gameObject);
            } 
        }
    }
}

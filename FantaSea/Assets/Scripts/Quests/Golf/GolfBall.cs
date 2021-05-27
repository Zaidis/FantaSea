using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public Transform loc;
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("River")) {
            transform.position = loc.position;
        }
    }
}

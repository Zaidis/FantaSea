using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkObject : MonoBehaviour
{

    public GameObject player;
    Vector3 startPos;
    float t;
    public float timeAmount;
    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        startPos = transform.position;
    }

    private void Update() {
        t += Time.deltaTime / timeAmount;
        transform.position = Vector3.Lerp(startPos, player.transform.position, t);
    }
}

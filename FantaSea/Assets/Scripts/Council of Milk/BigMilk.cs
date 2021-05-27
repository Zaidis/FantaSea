using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMilk : MonoBehaviour
{
    public GameObject target;
    Vector3 startPos;
    float t;
    public float timeAmount;
    private void Start() {
        startPos = transform.position;
    }

    private void Update() {
        t += Time.deltaTime / timeAmount;
        transform.position = Vector3.Lerp(startPos, target.transform.position, t);
    }
}

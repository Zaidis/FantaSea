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

    private void Update() {
        gameObject.transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, 1), transform.localPosition.z);
        transform.Rotate(0, 15 * Time.deltaTime, 0);
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

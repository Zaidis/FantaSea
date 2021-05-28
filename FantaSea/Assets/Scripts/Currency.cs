using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Player")) {
            collision.collider.gameObject.GetComponent<CurrencyManager>().CurrencyAmount += 1;

            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            CurrencyManager cm = other.gameObject.GetComponent<CurrencyManager>();
            cm.CurrencyAmount += 1;
            //print(other.gameObject.GetComponent<CurrencyManager>().CurrencyAmount);
            cm.currencyText.text = cm.CurrencyAmount.ToString();
            Destroy(this.gameObject);
        }
    }
}

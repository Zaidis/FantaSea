using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Pedistal : MonoBehaviour
{

    public LettersManager manager;
    public Transform placement;
    public List<GameObject> milks = new List<GameObject>();
    public Image closedUI;
    public TextMeshProUGUI credits;
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
        Invoke("StartClose", 50);
    }

    public void StartClose() {
        StartCoroutine(CloseScreen());
    }

    IEnumerator CloseScreen() {
        float currentAlpha = closedUI.color.a;

        for(float i = 0; i < 1; i += Time.deltaTime) {
            Color newAlpha = new Color(0, 0, 0, Mathf.Lerp(currentAlpha, 1, i));
            closedUI.color = newAlpha;
            yield return null;
        }
        Invoke("TurnOnText", 1.75f);
    }

    public void TurnOnText() {
        credits.gameObject.SetActive(true);
    }

}

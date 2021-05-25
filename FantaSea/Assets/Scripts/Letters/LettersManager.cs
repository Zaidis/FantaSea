using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LettersManager : MonoBehaviour
{

    public List<Letter> letters = new List<Letter>();

    /// <summary>
    /// Called when you touch a letter.
    /// </summary>
    public void CheckID(int id) {
        for(int i = 0; i < letters.Count; i++) {
            if(letters[i].id == id) {
                letters[i].GetComponent<TextMeshProUGUI>().color = Color.yellow;
                return;
            }
        }
    }
}

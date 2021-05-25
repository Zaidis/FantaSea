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
                if (CheckIfDone()) {
                    print("Ah ya did it didnt ya"); //get all the letters
                }
                return;
            }
        }
    }

    /// <summary>
    /// Checks to see if all the letters are obtained.
    /// </summary>
    public bool CheckIfDone() {
        print("Checking if done");
        for(int i = 0; i < letters.Count; i++) {
            if(letters[i].GetComponent<TextMeshProUGUI>().color != Color.yellow) {
                return false;
            }
        }
        return true;
    }
}

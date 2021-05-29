using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "New Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea()]
    public List<string> lines = new List<string>();
    public string name;
}

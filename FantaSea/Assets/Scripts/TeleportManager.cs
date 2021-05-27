using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform golfIsland;
    public Transform councilIsland;
    public CharacterController cc;

    private void Start() {
        cc = GetComponent<CharacterController>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            cc.enabled = false;
            transform.position = new Vector3(golfIsland.position.x, golfIsland.position.y, golfIsland.position.z);
            print("I teleported");
            cc.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.I)) {
            cc.enabled = false;
            transform.position = new Vector3(councilIsland.position.x, councilIsland.position.y, councilIsland.position.z);
            print("I teleported");
            cc.enabled = true;
        }
    }
}

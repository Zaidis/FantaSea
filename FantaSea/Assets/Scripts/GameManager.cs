using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public PlayerMovement m_player;
    public Boat_Base m_boat;
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }



}

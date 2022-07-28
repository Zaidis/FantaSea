using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public PlayerMovement m_player;
    public Boat_Base m_boat;

    public enum CurrentSetting { 
      human, 
      boat,
    
    };

    public CurrentSetting mySetting;
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

        mySetting = CurrentSetting.human;
    }

    public void SwitchCharacters(Transform p , Transform b) {
        if (mySetting == CurrentSetting.boat) {
            PlayerMovement player = Instantiate(m_player, p.position, Quaternion.identity);
            Destroy(FindObjectOfType<Boat_Base>().gameObject);
            mySetting = CurrentSetting.human;

            SeaManager.instance.sea.ChangeTarget(player.gameObject);

        }
        else {
            Boat_Base player = Instantiate(m_boat, b.position, Quaternion.identity);
            Destroy(FindObjectOfType<PlayerMovement>().gameObject);
            mySetting = CurrentSetting.boat;

            SeaManager.instance.sea.ChangeTarget(player.gameObject);
        }


    }

}

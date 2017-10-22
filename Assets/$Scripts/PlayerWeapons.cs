using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour {

    
    public GameObject[] barrels = null;
    public int activeLevel = 1;
    public int maxLevel = 3;
    //public delegate void ActivateBarrels(int powerlevel);
    //public delegate void OnPowerupChange();
    //public event OnPowerupChange powerUpChange;


    public void UpgradeWeapons() {
        if (activeLevel < maxLevel) {
            activeLevel++;
            barrels[activeLevel - 1].SetActive(true);
        }
        else {
            //Give player points?
            Debug.Log("max level given, have some points");
        }
    }

    public void DowngradeWeapons() {
        if (activeLevel > 1) {
            activeLevel--;
            
            barrels[activeLevel ].SetActive(false);
            Debug.Log("disabled "+ barrels[activeLevel ]);
        }
        else {
            // what consequences should there be to a level one stun?
            Debug.Log("CAnt disable any... more lucky you!");
        }

    }
}

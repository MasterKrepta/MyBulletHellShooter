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


    private void Update() {
        #region DEBUG TOOLS
        /*
        if (Input.GetKeyDown(KeyCode.P)) {
            DisableAllWeapons();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            EnableWeapons();
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            GameManager.Instance.CallPlayerDeath();
        } */
#endregion
    } 
    private void OnEnable() {
        GameManager.PlayerDeath += DisableAllWeapons;
        GameManager.RespawnPlayer += EnableWeapons;
    }
    private void OnDisable() {
        GameManager.PlayerDeath -= DisableAllWeapons;
        //GameManager.RespawnPlayer -= EnableWeapons;
    }

    public void DowngradeWeapons() {
        if (activeLevel > 1) {
            activeLevel--;
            
            barrels[activeLevel ].SetActive(false);
            Debug.Log("disabled "+ barrels[activeLevel ]);
        }
        else {
            // what consequences should there be to a level one stun?
            Debug.Log("Cant disable any... more lucky you!");
        }

    }
     void DisableAllWeapons() {
        foreach (GameObject go in barrels) {
            go.SetActive(false);
        }
        Debug.Log("WeaponsOffline");
    }
    void EnableWeapons() {
        List<GameObject> activeWeapons = GetWeaponsToActivate();
        foreach (GameObject go in activeWeapons) {
            go.SetActive(true);
        }
    }

    List<GameObject> GetWeaponsToActivate() {
        List<GameObject> weaponsToActivate = new List<GameObject>();
        for (int i = 0; i < barrels.Length; i++) {
            Debug.Log("i is " + i);
            if (i < (activeLevel )) {
                weaponsToActivate.Add(barrels[i]);
            }
            else {
                barrels[i].SetActive(false);
            }
        }
        return weaponsToActivate;
    }
    
}

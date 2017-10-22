using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBarrels : MonoBehaviour {

    public GameObject[] barrels = null;
    public int activeLevel = 0;
    //public delegate void ActivateBarrels(int powerlevel);
    //public delegate void OnPowerupChange();
    //public event OnPowerupChange powerUpChange;
    void OnEnable() {
        
    }
    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void ActivateBarrels(int powerlevel) {
        foreach(GameObject go in barrels) {
            if(go.activeSelf == true) {
                Debug.Log(go.name + " is active");
            }
        }
    }
}

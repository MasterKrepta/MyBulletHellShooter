using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    int value = 5;
    private enum  lootTypes {
        basic, twoXMulti, platnum 
    };

    public void GenRandomLootType() {
        //TODO maybe change the type of loot with difficulty
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            GameManager.Instance.CallEarnedCredits(value);
            this.gameObject.SetActive(false);
        }
    }
}

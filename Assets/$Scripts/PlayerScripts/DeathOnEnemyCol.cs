using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnEnemyCol : MonoBehaviour {

    

    private void Start() {
        }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            
            GameManager.Instance.CallPlayerDeath();
        }
    }
}

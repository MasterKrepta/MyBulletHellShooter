using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnEnemyCol : MonoBehaviour {

    Health playerHealth;

    private void Start() {
        playerHealth = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            //TODO: use a delegate instead 
            playerHealth.Die();
        }
    }
}

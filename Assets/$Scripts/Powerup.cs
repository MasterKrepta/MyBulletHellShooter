using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    PlayerWeapons playerWeapons;

    private void Awake() {
        playerWeapons = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerWeapons>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerWeapons.UpgradeWeapons();
        //playerWeapons.DowngradeWeapons();  // FOR TESTING ONLY
        Destroy(gameObject);
        
    }
}

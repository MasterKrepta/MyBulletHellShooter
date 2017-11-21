
using UnityEngine;

public class PowerDownOnCol : MonoBehaviour {

    PlayerWeapons playerWeapons;

    private void Start() {
        try {
            playerWeapons = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerWeapons>();
        }
        catch {
            Destroy(this.gameObject);
        }
    }

 
    private void OnTriggerEnter2D(Collider2D other) {
        if(playerWeapons != null) {
            playerWeapons.DowngradeWeapons();
            Destroy(gameObject);
        }
        
    }
}

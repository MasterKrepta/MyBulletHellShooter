
using UnityEngine;

public class PowerDownOnCol : MonoBehaviour {

    PlayerWeapons playerWeapons;

    private void Start() {
        playerWeapons = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerWeapons>();
    }

    private void Update() {
        if(playerWeapons == null) {
            playerWeapons = GameObject.FindGameObjectWithTag("Player")
                                   .GetComponent<PlayerWeapons>(); // HACK this seems like a terrible idea, but for now it will work
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        playerWeapons.DowngradeWeapons();
        Destroy(gameObject);
    }
}

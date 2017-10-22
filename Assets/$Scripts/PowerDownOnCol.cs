
using UnityEngine;

public class PowerDownOnCol : MonoBehaviour {

    PlayerWeapons playerWeapons;

    private void Awake() {
        playerWeapons = GameObject.FindGameObjectWithTag("Player")
                                    .GetComponent<PlayerWeapons>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerWeapons.DowngradeWeapons();
        Destroy(gameObject);
    }
}

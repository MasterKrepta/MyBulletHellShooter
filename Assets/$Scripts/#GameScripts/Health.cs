using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int currentHealth;
    public int maxHealth;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    public void TakeDamage(int damage) {
        Debug.Log(gameObject.name + " has taken " + damage + " points of damage");
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Die();
        }
    }
    void Die() {
        //play death animation and sound effects
        Destroy(this.gameObject);
    }
}

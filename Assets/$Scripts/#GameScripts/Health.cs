using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int currentHealth;
    public int maxHealth;
    // Use this for initialization
    private void OnEnable() {
        //GameManager.EarnedPoints += Die;
    }

    private void OnDisable() {
        //GameManager.EarnedPoints -= Die;
    }
    void Start () {
        currentHealth = maxHealth;
	}

    public void TakeDamage(int damage) {
        //Debug.Log(gameObject.name + " has taken " + damage + " points of damage");
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Die();
        }
    }
    void Die() {
        //play death animation and sound effects
        
        // Modify the points for each enemy based on health
        int pointsToGive = (int)(maxHealth * GameManager.Instance.pointModifier);
        GameManager.Instance.delPointsEarned(pointsToGive);
        
        Destroy(this.gameObject);
        
    }
}

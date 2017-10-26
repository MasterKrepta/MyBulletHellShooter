using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int currentHealth;
    public int maxHealth;
    // Use this for initialization
    private void OnEnable() {
        GameManager.PlayerDeath += Die;
        GameManager.PlayerDeath += ResetHealth;

    }

    private void OnDisable() {
       // GameManager.PlayerDeath -= ResetHealth;
    }
    void Start () {
        ResetHealth();
	}

    public void TakeDamage(int damage) {
        //Debug.Log(gameObject.name + " has taken " + damage + " points of damage");
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Die();
        }
    }
    public void Die() {

        //play death animation and sound effects

        #region PlayerHealthCode
        currentHealth = 0;
        if(this.tag == "Player") {
            this.gameObject.SetActive(false);
            return;
        }
#endregion

        #region EnemyHealthCode
        // Modify the points for each enemy based on health
        int pointsToGive = (int)(maxHealth * GameManager.Instance.pointModifier);
        GameManager.Instance.CallEarnedPoints(pointsToGive);
        Destroy(this.gameObject);
#endregion
    }
    public void ResetHealth() {
        
        currentHealth = maxHealth;
    }

 
}

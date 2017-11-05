using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    public int currentHealth;
    public int maxHealth;

    
    // Use this for initialization
    private void OnEnable() {
        GameManager.PlayerDeath += PlayerDies;
        GameManager.PlayerDeath += ResetHealth;
        
    }

    private void OnDisable() {
       GameManager.PlayerDeath -= ResetHealth;
        GameManager.PlayerDeath -= PlayerDies;
    }
    void Start () {
        ResetHealth();
        
	}

    public void TakeDamage(int damage) {
        //Debug.Log(gameObject.name + " has taken " + damage + " points of damage");
        currentHealth -= damage;
        if (this.currentHealth <= 0 && this.gameObject.tag == "Player") {
            //Debug.Log("PlayerDies");
            GameManager.Instance.CallPlayerDeath();
        }
        else if (this.currentHealth <= 0 && this.gameObject.tag != "Player") {
            currentHealth = 0;
            //Debug.Log("EnemyDies");
            EnemyDeath();
        }
    }

    public void PlayerDies() {
        //play death animation and sound effects
        
        if (this.gameObject.tag == "Player") {
            currentHealth = 0;
            this.gameObject.SetActive(false);
            return;
        }
    }

    public void EnemyDeath() {
        // Modify the points for each enemy based on health
       // if (this.tag != "Player") {
            currentHealth = 0;
            int pointsToGive = (int)(maxHealth * GameManager.Instance.pointModifier);
            GameManager.Instance.CallEarnedPoints(pointsToGive);

            GameManager.Instance.CallSpawnLoot();
            Destroy(this.gameObject);
        
      //  }
    }    

        void ResetHealth() {
        
        currentHealth = maxHealth;
        
        }

 
    
}

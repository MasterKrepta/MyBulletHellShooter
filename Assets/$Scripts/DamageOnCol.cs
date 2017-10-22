using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DamageOnCol : MonoBehaviour {
    private BoxCollider2D col;
    [SerializeField]
    private int power;

    private void Start() {
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        if(power == 0) {
            power = 1; // default setting 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Health objHealth = other.GetComponent<Health>();
        if (objHealth != null) {
            objHealth.TakeDamage(power);
        }

        
    }
}

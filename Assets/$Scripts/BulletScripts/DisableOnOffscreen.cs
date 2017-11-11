using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnOffscreen : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer rend;
    private void OnEnable() {
        rend = GetComponentInChildren<SpriteRenderer>();
        
    }

    private void Update() {
        if(!rend.isVisible) {
            
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);
    }
}

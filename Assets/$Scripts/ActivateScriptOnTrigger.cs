using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScriptOnTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        
        foreach(MonoBehaviour mb in collision.GetComponentsInChildren<MonoBehaviour>()) {
            mb.enabled = true;
        }
    }
}

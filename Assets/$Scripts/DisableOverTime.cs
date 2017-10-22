using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOverTime : MonoBehaviour {

    // Use this for initialization

    private void OnEnable() {
        Invoke("Destroy", 1f);
    }

    void Destroy() {
        gameObject.SetActive(false);
    }
    private void OnDisable() {
        CancelInvoke();
    }
}

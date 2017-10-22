using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform bulletPrefab;
    public float shootDelay = .5f;
	// Use this for initialization
	void Start () {
        Invoke("ShootForward", shootDelay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShootForward() {
        if (bulletPrefab != null) {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        Invoke("ShootForward", shootDelay);
    }
}

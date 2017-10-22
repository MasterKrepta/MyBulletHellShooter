using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float shootDelay = .5f;
    
    void Start () {

        InvokeRepeating("ShootForward", shootDelay, shootDelay);
    }
    void ShootForward() {
        GameObject obj = ObjectPooler.current.GetPooledObjects();

        if (obj == null) return;
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.transform.gameObject.SetActive(true);
        
    }
}

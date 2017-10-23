using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public float shootDelay = .5f;
    

    void Start () {
        
        
        InvokeRepeating("ShootForward", shootDelay, shootDelay);
    }
    void  ShootForward() {
        PoolingManager.InstantiatePooled(bulletPrefab, transform.position, transform.rotation);
        
        /*
        GameObject obj = ObjectPooler.current.GetPooledObjects(bulletPrefab);
        if (obj == null) return;
            //GameObject newObj = bsc.ChangeSprite(obj);

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.transform.gameObject.SetActive(true);
        */

    }
}

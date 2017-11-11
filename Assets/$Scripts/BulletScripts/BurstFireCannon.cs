using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireCannon : MonoBehaviour
{

    public GameObject bulletPrefab;
    
    public float numRounds = 3;
    public float fireRate = 3;
    public float burstRate = .5f;
    
    float time = 0;
    // Use this for initialization
    void Start() {
        time = fireRate;
        
    }

    private void Update() {
        
        if (time > 0) {
           // Debug.Log("start counting down");
            time -= Time.deltaTime;
        }

        if (time <= 0) {
            
            StartCoroutine(FireBurst());
            time = fireRate;
        }
        

    }

    IEnumerator FireBurst() {
        for (int i = 0; i < numRounds; i++) {
            PoolingManager.InstantiatePooled(bulletPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(burstRate);
        }
        

    }
} 





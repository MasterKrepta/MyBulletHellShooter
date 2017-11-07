using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndFireAtTarget : MonoBehaviour {

    public GameObject bulletPrefab;

    public Transform target;

    public float numRounds = 1;
    public float fireRate = 2;
    public float burstRate = .3f;
    bool canFire = true;
    bool burstover = false;
    private Vector2 dir;
    float time;

	// Use this for initialization
	void Start () {
        time = fireRate;

	}
	
	// Update is called once per frame
	void Update () {
        if (!canFire && burstover) {
            time -= Time.deltaTime;
            if(time <= 0) {
                time = fireRate;
                canFire = true;
            }
        }
        else {
            canFire = false;
            dir = AimAtTarget();
            Fire(dir);
        }

	}

    Vector2 AimAtTarget() {
        Vector2 dir = target.position - transform.position;
        return dir;
    }

    void Fire(Vector2 target) {
        float time = burstRate;
        for (int b = 0; b < numRounds; b++) {
            //GameObject go = Instantiate(bulletPrefab, transform.position, transform.rotation);
            PoolingManager.InstantiatePooled(bulletPrefab, transform.position, transform.rotation);
            while (time > 0) {
                time -= Time.deltaTime;
                Debug.Log("dont fire");
            }
            Debug.Log("we are here");
            time = burstRate;
        }

    }
}

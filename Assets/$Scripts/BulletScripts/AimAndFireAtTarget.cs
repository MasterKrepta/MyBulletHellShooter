using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndFireAtTarget : MonoBehaviour {

    public GameObject bulletPrefab;

    public Transform target;

    public float numRounds = 1;
    public float fireRate = 3;
    public float burstRate = .5f;
    bool canFire = true;
    bool burstover = false;
    private Vector2 dir;
    float time = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine( Fire());

    }
	




    IEnumerator Fire() {

        for (int b = 0; b < numRounds; b++) {

            /*Vector3 targetPos = target.position;
            Vector3 targetPosFlattened = new Vector3(targetPos.x, targetPos.y, 0);
            transform.LookAt(targetPosFlattened); */

            PoolingManager.InstantiatePooled(bulletPrefab, transform.position, transform.rotation);
            
            Debug.Log("Fire burst " + b);
            yield return new WaitForSeconds(burstRate);
        }

        Debug.Log("end  burst");
        yield return new WaitForSeconds(fireRate);
        Debug.Log("end of fire");
    }
}

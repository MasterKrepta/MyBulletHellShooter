using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour {

    public Transform target;
    public float trackingSpeed = 30f;

	// Use this for initialization
	void Start () {
        try {
            target = GameObject.FindWithTag("Player").transform;
        }
        catch {
            Debug.Log("player cant be set so disable");
            this.gameObject.SetActive(false); // hack to disable if we are between spawns. 
                                              // should TODO this as an event to stop all weapons from firing until player respawns
        }
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        /*
        Quaternion rotation = Quaternion.LookRotation
            (target.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
     */
    }
}

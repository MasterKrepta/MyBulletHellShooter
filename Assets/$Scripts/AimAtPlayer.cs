using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour {

    public Transform target;
    public float trackingSpeed = 30f;

    // Use this for initialization
    private void Start() {
        TakeAim();
    }
    private void OnEnable() {
        GameManager.PlayerDeath += TargetLostOnPlayerDeath;
        GameManager.RespawnPlayer += TakeAim;
    }

    private void OnDisable() {
        GameManager.PlayerDeath -= TargetLostOnPlayerDeath;
        GameManager.RespawnPlayer -= TakeAim;
    }
    void  TakeAim() {
        //try {
            target = GameObject.FindWithTag("Player").transform;
        Debug.Log("target aquired");
        //}
        //catch {
        // Debug.Log("player cant be set so disable");
        //  this.gameObject.SetActive(false); // hack to disable if we are between spawns. 
        // should TODO this as an event to stop all weapons from firing until player respawns
        //}
    }
    void TargetLostOnPlayerDeath() {
        this.gameObject.SetActive(false);
        Debug.Log("disabled because the player died");
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
